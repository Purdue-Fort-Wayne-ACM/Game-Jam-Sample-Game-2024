using UnityEngine;

public class MainMenuUIController : MonoBehaviour {

    #region Methods
    public void OnStartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnExitGame() {
        Application.Quit();
    }

    public void OnMainMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Engine.IsModal = false;
    }
    #endregion

    #region Unity Methods
    [HideInInspector]
    public GameObject[] EndGameScreens = new GameObject[2];

    private void Start() {
        int i = 0;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Finish")) {
            EndGameScreens[i] = go;
            go.SetActive(false);
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Player>() != null) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
    #endregion

}
