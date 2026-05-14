using UnityEngine;
using System.Collections.Generic;

public class Kasse : MonoBehaviour
{
    // Hier speichern wir alle Kunden, die gerade an der Kasse stehen
    private Queue<Kunde> warteschlange = new Queue<Kunde>();

    // Diese Funktion wird vom Kunden aufgerufen, wenn er ankommt
    public void KundeAnstellen(Kunde neuerKunde)
    {
        warteschlange.Enqueue(neuerKunde);
    }

    // Diese Unity-Funktion wird automatisch aufgerufen, wenn du auf den Collider klickst
    void OnMouseDown()
    {
        Debug.Log("Kasse wurde angeklickt! Warteschlange hat " + warteschlange.Count + " Kunden."); 
        // Prüfen, ob überhaupt jemand an der Kasse steht
        if (warteschlange.Count > 0)
        {
            // Den ersten Kunden in der Schlange nehmen und abkassieren
            Kunde aktuellerKunde = warteschlange.Dequeue();
            aktuellerKunde.AbkassiertWerden();
        }
    }

}
