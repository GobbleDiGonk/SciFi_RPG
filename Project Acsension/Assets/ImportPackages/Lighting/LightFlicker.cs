using UnityEngine;

public class RandomLightAndEmissionFlicker : MonoBehaviour
{
    [Header("Emission (Material) Settings")]
    public Renderer targetRenderer;           // Emission 있는 오브젝트 Renderer
    public Color emissionColor = Color.white; // 기본 발광 색상
    public float minEmission = 0.2f;          // 최소 발광 강도
    public float maxEmission = 1.5f;          // 최대 발광 강도

    [Header("Light Settings")]
    public Light targetLight;                 // 실제 광원 (선택사항)
    public float minLightIntensity = 0.2f;
    public float maxLightIntensity = 1.5f;

    [Header("Flicker Speed")]
    public float flickerSpeed = 0.1f;         // 깜빡임 주기 (초 단위)

    private Material _material;
    private float _timer;

    void Start()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();

        if (targetRenderer != null)
        {
            _material = targetRenderer.material;
            _material.EnableKeyword("_EMISSION");
        }

        if (targetLight == null)
            targetLight = GetComponent<Light>();
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            float intensity = Random.Range(minEmission, maxEmission);

            // --- Emission 깜빡임 ---
            if (_material != null)
            {
                Color finalColor = emissionColor * intensity;
                _material.SetColor("_EmissionColor", finalColor);
            }

            // --- 라이트 깜빡임 ---
            if (targetLight != null)
            {
                targetLight.intensity = Random.Range(minLightIntensity, maxLightIntensity);
            }

            // 다음 깜빡임까지의 시간 랜덤
            _timer = Random.Range(flickerSpeed * 0.5f, flickerSpeed * 2f);
        }
    }
}
