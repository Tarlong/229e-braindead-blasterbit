using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    [SerializeField] string Scenename;
    private void OnCollisionEnter2D(Collision2D flag)
    {
        if (flag.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(Scenename);
        }
    }
}
    
