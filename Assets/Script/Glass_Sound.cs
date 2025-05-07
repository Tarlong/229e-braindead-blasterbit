using UnityEngine;

public class Glass_Sound : MonoBehaviour
{
    [SerializeField] AudioClip hitGlass;

    private void OnCollisionEnter2D(Collider2D hp)
    {
        if (hp.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(hitGlass, transform.position);
        }
    }
}
