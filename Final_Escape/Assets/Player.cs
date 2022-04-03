using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;
    //
    public float _movespeed = 7f;
    public float _mousespeed = 8f;
    //
    private float _horizontal;
    private float _vertical;
    private Vector3 move;
    //
    private float mouseX = 0;
    //
    CharacterController character;


    // Item - Bool
    bool _key = false;
    bool _Carrot = false;

    // Item - Env
    float _CarrotTime = 0f;
    float _CarrotBufTime = 3.5f;


    private void Awake()
    {
        // Single
        if (instance == null) instance = this;
        else if (instance != this) Destroy(instance);

        // charcter
        character = GetComponent<CharacterController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        // 키보드
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        move = new Vector3(_horizontal, 0, _vertical);

        // 마우스
        mouseX += Input.GetAxis("Mouse X") * _mousespeed;
        character.Move(transform.TransformDirection(move).normalized * Time.deltaTime * _movespeed);
        transform.eulerAngles = new Vector3(0, mouseX, 0);

        // 일시정지
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameManager.instance.Victoty_msg = "pause";
            GameManager.instance.Result();
        }

        Debug.Log(_movespeed);

        // Item
        Carrot();
            
    }

    public void Carrot()
    {
        if (_Carrot) {
            _CarrotTime += Time.deltaTime;
        }

        if (_CarrotTime >= _CarrotBufTime) {
            _Carrot = false;
            _movespeed = 5f;
            _CarrotTime = 0f;
            GameManager.instance.UI_CARROT.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("_Key"))
        {
            // Bool
            _key = true;

            // Object
            Destroy(col.gameObject);
            GameManager.instance.UI_KEY.SetActive(true);
        }
        if (col.gameObject.CompareTag("_Carrot"))
        {
            // Bool
            _Carrot = true;

            // Spped
            _movespeed = 20f;

            // Object & UI
            Destroy(col.gameObject);
            GameManager.instance.UI_CARROT.SetActive(true);

        }
        if (col.gameObject.CompareTag("_Door") && _key)
        {
            // UI
            GameManager.instance.Victoty_msg = "win";
            GameManager.instance.Result();
        }

        if (col.gameObject.CompareTag("_Enemy"))
        {
            // UI
            GameManager.instance.Victoty_msg = "lose";
            GameManager.instance.Result();
        }
    }
}
