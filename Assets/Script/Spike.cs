using UnityEngine;

public class Spike : MonoBehaviour
{

    [SerializeField] int atkSpike = 2;
  
    // ทำลายผู้ล่นเมื่อเหยีบหนาม
    private void OnCollisionEnter2D(Collision2D spike)
    {
        if (spike.gameObject.CompareTag("Player"))
        {
            Player player = spike.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(atkSpike);
            }

        }

        
    }
}
