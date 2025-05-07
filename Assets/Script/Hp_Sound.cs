using UnityEngine;
using UnityEngine.Audio;

public class CoinSound : MonoBehaviour
{
    [SerializeField] AudioClip getHP;

    private void OnTriggerEnter2D(Collider2D hp)
    {
        if (hp.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(getHP, transform.position);
            
        }
    }
}