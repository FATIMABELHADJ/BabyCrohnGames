using UnityEngine;
using UnityEngine.UI;

public class QuitButtonScript : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu !");
        Application.Quit(); // Quitte le jeu (fonctionne en build)
    }
}
