using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int coin = 0;
    public int HP = 0;


    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ไม่ลบตอนเปลี่ยนฉาก
        }
        else
        {
            Destroy(gameObject); // ป้องกันการซ้ำ
        }
        ResetCoin();
    }

    public void AddCoin(int amount)
    {
        coin += amount;
    }

    public int GetCoin()
    {
        return coin;
    }

    public void ResetGame() // เหรียญ = 0 เมื่อเริ่มใหม่
    {
        coin = 0;
        HP = 0;
    }

    public void AddHP(int amount)
    {
        HP += amount;
    }

    public int GetHP()
    {
        return HP;
    }

    public void ResetCoin()
    {
        coin = 0;
    }
}
