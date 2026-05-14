using UnityEngine;

public class KundenSpawner : MonoBehaviour
{
    public GameObject kundenPrefab; // Hier ziehst du dein Kunden-Prefab rein
    public float spawnIntervall = 20.0f; // 20 Sekunden
    
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnIntervall)
        {
            // Spawnt den Kunden genau an der Position des Spawners
            Instantiate(kundenPrefab, transform.position, Quaternion.identity);
            
            // Timer zurücksetzen
            timer = 0.0f;
        }
    }
}
