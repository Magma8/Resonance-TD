using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float nextWaveCountdown = 5f;

    [SerializeField] private float countdown = 2f;
    [SerializeField] private float spawnGap = 0.5f;

    public TextMeshProUGUI waveTimerText;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = nextWaveCountdown;
        }

        countdown -= Time.deltaTime;

        waveTimerText.text = Mathf.Floor(countdown).ToString(); 
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnGap);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
