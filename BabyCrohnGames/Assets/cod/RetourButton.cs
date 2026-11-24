using UnityEngine;
using UnityEngine.SceneManagement; // Bach nkhdmo b scenes

public class RetourButton : MonoBehaviour
{
    public void RetournerEnArrière()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0) // Wach kayn scene qbl ?
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Rj3 l’scène li qbl
        }
    }
}
