using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] AudioClip shooting;
    [SerializeField] AudioClip hitEnemy;
    [SerializeField] AudioClip hitGlass;

    public float bulletLifetime = 3f;
    public int bulletDamage = 5;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        AudioSource.PlayClipAtPoint(shooting, transform.position);
        Destroy(gameObject, bulletLifetime);
    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        // �ԧⴹ�ѵ��
        if (bullet.CompareTag("Enemy"))
        {
            AudioSource.PlayClipAtPoint(hitEnemy, transform.position);
            Enemy enemy = bullet.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }
        // �ԧⴹ��Ш�
        if (bullet.CompareTag("Glass"))
        {
            AudioSource.PlayClipAtPoint(hitGlass, transform.position);
            Destroy(bullet.gameObject);
            Destroy(gameObject);
        }
        // �ԧⴹ���
        if (bullet.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
