using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }
        SceneManager.LoadScene("LV_1");
    }

    public void OpenCredit() // �ôԵ
    {
        SceneManager.LoadScene("Credit"); 
    }

    public void BackTOManu() // ��Ѻ˹������
    {
        SceneManager.LoadScene("Menu");
    }

    public void CreditAssets()
    {
        SceneManager.LoadScene("Credit_2");
    }

    public void CreditSong()
    {
        SceneManager.LoadScene("Credit_3");
    }

    public void QuitGame()
    {
        Application.Quit(); // �͡��
        Debug.Log("Quit Game");
    }
}
