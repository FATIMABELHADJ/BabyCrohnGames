using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name); // T7afed l’safha li nta fiha
        PlayerPrefs.Save();
    }
}
