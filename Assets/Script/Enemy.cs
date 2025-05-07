using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    int atkEnemy = 1;

    //�������͹���
    Rigidbody2D rb2D;
    public float moveSpeed = 2f;
    private bool movingRight = true;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb2D.linearVelocity = new Vector2(movingRight ? moveSpeed : -moveSpeed, rb2D.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ҫ��Ѻ TurnPoint ������¹���㹡���Թ
        if (other.CompareTag("TurnPoint"))
        {
            Flip();
        }
    }
    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // ��Ѻ��ҹ sprite
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Player"))
        {
            Player player = enemy.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(atkEnemy);
            }
        }

        if (enemy.gameObject.CompareTag("Enemy")) // �Թ���ѹ�ͧ��������¹�ҧ�Թ
        {
            Flip();
        }
    }

    public void TakeDamage(int damage)// ����Ѻ������ͧ����Ф�
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
