using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //���§��Сͺ
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip dieSound;
    [SerializeField] AudioClip playerTakeDamage;
    
    private AudioSource audioSource;
    private bool isWalkingSoundPlaying = false; // ������Թ���躹������� �����������§੾�е͹���躹���

    //////////////////////////////////  �����  ///////////////////////////////////////////////////

    Rigidbody2D rb2d;
    public float moveX;
    public float Speed;

    //jump
    public float jumpForce;
    bool isJumping;

    //Shooting
    [SerializeField] Rigidbody2D bulletprefab;
    [SerializeField] Transform shootPoint;

    // Coin Player
    int coin;
    [SerializeField]public Text coinUI;

    //Hp Player
    int hpPlayer = 3;
    [SerializeField] public Text hpUI;

    //////////////////////////////////  �����  ///////////////////////////////////////////////////

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (GameManager.Instance.GetHP() <= 0)
        {
            GameManager.Instance.AddHP(hpPlayer); // ���� HP �á������ GameManager
        }

        hpPlayer = GameManager.Instance.GetHP(); // �֧����� Player

        // ��Ǩ�ͺ��õ�駤�� AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walk
        moveX = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(moveX * Speed, rb2d.linearVelocity.y);
        

        // Jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            isJumping = true;
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }

        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Get click point
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red, 3f);

            if (hit.collider != null)
            {

                Vector2 projectileVelocity = CalculatProjectileVelocity(shootPoint.position, hit.point, 1f);

                Rigidbody2D shootBullet = Instantiate(bulletprefab, shootPoint.position, Quaternion.identity);

                shootBullet.linearVelocity = projectileVelocity;
            }
            
        }

        //��ҵ���Фõ��������Фèе��
        if (transform.position.y < -30f) // ��˹������֡ ��Ҷ֧�дѺ���ǵ���Фèе��
        {
            hpPlayer = 0;
            GameManager.Instance.AddHP(0);
            Die();
        }

        hpUI.text = "HP : " + hpPlayer.ToString();
        coinUI.text = "Coin : " + GameManager.Instance.GetCoin().ToString();
    }

    //CalculatProjectile
    Vector2 CalculatProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);

        return projectileVelocity;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        /////////////�����խ//////////////

        if (player.gameObject.CompareTag("Bronze_Coin")) //���խ �ͧᴧ
        {
            Destroy(player.gameObject);
            coin += 1;
            coinUI.text = "Coin : " + coin.ToString();
            GameManager.Instance.AddCoin(1);

        }

        if (player.gameObject.CompareTag("Gold_Coin")) // ���խ �ͧ
        {
            Destroy(player.gameObject);
            coin += 10;
            coinUI.text = "Coin : " + coin.ToString();
            GameManager.Instance.AddCoin(10);

        }

        if (player.gameObject.CompareTag("Silver_Coin")) // ���խ �Թ
        {
            Destroy(player.gameObject);
            coin += 5;
            coinUI.text = "Coin : " + coin.ToString();
            GameManager.Instance.AddCoin(5);

        }
        ////////////////////////////////
        
        if (player.gameObject.CompareTag("HP")) // �������ʹ
        {
            Destroy(player.gameObject);
            hpPlayer += 1;
            coinUI.text = "Hp : " + hpPlayer.ToString();
            GameManager.Instance.AddHP(1);

        }
    }

    private void OnCollisionEnter2D(Collision2D player)
    {
        //����ҵ���Ф����躹�������
        if (player.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }  
    }

    public void TakeDamage(int damage)
    {
        hpPlayer -= damage;
        AudioSource.PlayClipAtPoint(playerTakeDamage, transform.position);

        GameManager.Instance.AddHP(-damage); // �ѻവ GameManager ����

        if (hpPlayer <= 0)
        {
            GameManager.Instance.AddHP(-1);
            Die();
        }
    }

    void Die()
    {

        AudioSource.PlayClipAtPoint(dieSound, transform.position);
        Debug.Log("Player Died");

        GameObject pauseMenu = GameObject.Find("Pause_Manager");
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            if (pauseMenu == null)
            {
                Debug.Log("PauseMenu NOT FOUND");
                Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("PauseMenu FOUND");
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        
        Destroy(gameObject);

        SceneManager.LoadScene("Loss");

    }
}
