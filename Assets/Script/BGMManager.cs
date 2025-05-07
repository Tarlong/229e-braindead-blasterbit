using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;
    [SerializeField] AudioClip BGSong;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ������ŧ��������������¹�ҡ
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BGSong;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.Play();

    }
}
