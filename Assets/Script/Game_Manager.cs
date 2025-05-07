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
            DontDestroyOnLoad(gameObject); // ���ź�͹����¹�ҡ
        }
        else
        {
            Destroy(gameObject); // ��ͧ�ѹ��ë��
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

    public void ResetGame() // ����­ = 0 ��������������
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
