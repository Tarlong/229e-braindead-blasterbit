using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject player;

    private bool isPaused = false;

    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = pauseMenu.activeSelf;
            pauseMenu.SetActive(!isActive);

            Time.timeScale = isActive ? 1f : 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // หยุดเวลาในเกม
        isPaused = true;
    }

    ///////////////////////////////////////////////////////////
    
    public void ResumeGame() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    ///////////////////////////////////////////////////////////
    
    public void RestartGame() // เล่นใหม่
    {
        Time.timeScale = 1f;
        GameManager.Instance.ResetGame(); // ล้าง coin และ HP ก่อนเริ่มเกมใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    ///////////////////////////////////////////////////////////
    
    public void QuitGame() // ออกเกม
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
