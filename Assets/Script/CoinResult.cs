using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinResult : MonoBehaviour
{
    [SerializeField] Text coinText;

    void Start()
    {
        int totalCoin = GameManager.Instance.GetCoin(); // ดึง coin จาก GameManager
        coinText.text = "Coin : " + totalCoin.ToString();
    }

    public void ResetCoin()
    {
        GameManager.Instance.ResetCoin(); // เรียกรีเซ็ตจาก GameManager
    }
}
