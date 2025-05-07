using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinResult : MonoBehaviour
{
    [SerializeField] Text coinText;

    void Start()
    {
        int totalCoin = GameManager.Instance.GetCoin(); // �֧ coin �ҡ GameManager
        coinText.text = "Coin : " + totalCoin.ToString();
    }

    public void ResetCoin()
    {
        GameManager.Instance.ResetCoin(); // ���¡���絨ҡ GameManager
    }
}
