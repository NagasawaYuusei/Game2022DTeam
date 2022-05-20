using UnityEngine;

public class Floor3_2SwitchController : MonoBehaviour
{
    public static Floor3_2SwitchController Instance { get; private set; }
    [Header("è∞Ç™Ç†Ç¢ÇΩÇ©Ç«Ç§Ç©"), Tooltip("è∞Ç™Ç†Ç¢ÇΩÇ©Ç«Ç§Ç©")] public bool _isFloorOpened;
    Animator _switchAnim;
    // Start is called before the first frame update

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }  
    }

    private void Start()
    {
        _switchAnim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PsychokinesisObject")
        {
            _isFloorOpened = true;
            _switchAnim.SetBool("Switch", true);
        }
    }
}
