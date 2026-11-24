using UnityEngine;
using UnityEngine.UI;
public class HelpButton : MonoBehaviour
{
    public GameObject helpPanel; // Référence au panneau d'aide

    void Start()
    {
        // Assurez-vous que le panneau est caché au début
        if (helpPanel != null)
            helpPanel.SetActive(false);
    }

    public void ShowHelp()
    {
        if (helpPanel != null)
            helpPanel.SetActive(!helpPanel.activeSelf); // Affiche/Cache l'aide
    }
}
