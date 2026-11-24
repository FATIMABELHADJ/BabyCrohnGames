using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Importer SceneManager

public class SettingsButton : MonoBehaviour
{
    public GameObject SettingButton; // Le panneau des paramètres (UI)
    public string sceneSettingsName = "Settings"; // Nom de la scène Settings

    void Start()
    {
        if (SettingButton != null)
        {
           SettingButton.SetActive(false); // Masquer le menu au début
        }

        // Ajouter un événement au clic du bouton
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(ToggleSettingButton);
            btn.onClick.AddListener(AllerAuxSettings);
        }
    }

    void ToggleSettingButton()
    {
        if (SettingButton != null)
        {
            // Si settingsMenu est défini, on affiche/masque le menu
         SettingButton.SetActive(!SettingButton.activeSelf);
        }
    }

    public void AllerAuxSettings()
    {
        if (SettingButton == null) // Si pas de menu settings, on change de scène
        {
            SceneManager.LoadScene(sceneSettingsName);
        }
    }
}
