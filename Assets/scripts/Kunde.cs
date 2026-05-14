using UnityEngine;

public class Kunde : MonoBehaviour
{
    public float geschwindigkeit = 2.0f;
    public float lebensdauerNachKasse = 60.0f; // 1 Minute

    private Transform kassenZiel;
    private bool wartetAnKasse = false;
    private bool istFertigMitKasse = false;

    void Start()
    {
        // Automatisch die Kasse im Spiel finden (Deshalb ist der Tag "Kasse" so wichtig!)
        GameObject kassenObjekt = GameObject.FindGameObjectWithTag("Kasse");
        if (kassenObjekt != null)
        {
            kassenZiel = kassenObjekt.transform;
        }
    }

    void Update()
    {
        // Wenn der Kunde wartet, macht er in diesem Frame gar nichts
        if (wartetAnKasse) return;

        if (!istFertigMitKasse)
        {
            // 1. Phase: Zur Kasse laufen
            if (kassenZiel != null)
            {
                // Wir bewegen nur die X-Achse, Y und Z bleiben gleich (wichtig für deine Layer!)
                Vector3 zielPosition = new Vector3(kassenZiel.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, zielPosition, geschwindigkeit * Time.deltaTime);

                // Prüfen, ob wir (ungefähr) an der Kasse angekommen sind
// Prüfen, ob wir (ungefähr) an der Kasse angekommen sind
                if (Mathf.Abs(transform.position.x - kassenZiel.position.x) < 0.1f)
                {
                    wartetAnKasse = true;
                    Debug.Log("Ein Kunde ist an der Kasse angekommen!"); // <--- DAS HIER HINZUFÜGEN
                    kassenZiel.GetComponent<Kasse>().KundeAnstellen(this);
                }

            }
        }
        else
        {
            // 2. Phase: Nach rechts aus dem Bild laufen
            transform.Translate(Vector3.right * geschwindigkeit * Time.deltaTime);
        }
    }

    // Diese Funktion wird von der Kasse aufgerufen, wenn man draufklickt
    public void AbkassiertWerden()
    {
        wartetAnKasse = false;
        istFertigMitKasse = true;
        
        // Zerstört dieses GameObject nach der angegebenen Zeit (60 Sekunden)
        Destroy(gameObject, lebensdauerNachKasse);
    }
}
