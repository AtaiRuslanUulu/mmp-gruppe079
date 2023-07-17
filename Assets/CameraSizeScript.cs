using UnityEngine;

public class AdjustCameraSize : MonoBehaviour
{
    public float newFieldOfView = 1000f; // Neuer Wert für das Sichtfeld
    public float newOrthographicSize = 199000f; // Neuer Wert für die orthografische Größe

    void Start()
    {
        // Überprüfen, ob die Hauptkamera vorhanden ist
        if (Camera.main != null)
        {
            // Überprüfen, ob die Kamera eine perspektivische Kamera ist
            if (Camera.main.orthographic == false)
            {
                // Anpassen des Sichtfelds der Hauptkamera
                Camera.main.fieldOfView = newFieldOfView;
            }
            else
            {
                // Anpassen der orthografischen Größe der Hauptkamera
                Camera.main.orthographicSize = newOrthographicSize;
            }
        }
        else
        {
            Debug.LogWarning("Hauptkamera nicht gefunden!");
        }
    }
}
