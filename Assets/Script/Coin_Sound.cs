using UnityEngine;
using UnityEngine.Audio;

public class Coin_Sound : MonoBehaviour
{
    [SerializeField] AudioClip getCoin;
    private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(getCoin, transform.position);
        }
    }
}