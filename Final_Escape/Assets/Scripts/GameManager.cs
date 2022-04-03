using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //
    public GameObject UI_KEY;
    public GameObject UI_CARROT;
    public GameObject UI_Reuslt;
    //
    public Text UI_Reuslt_text;
    public Text UI_Regame_text;
    //
    public Button Btn_ReGame;
    public Button Btn_GoLobby;
    //
    public string  Victoty_msg;
    //
    float Item_carror_buf_time = 5f;


    private void Awake()
    {
        // Single
        if (instance == null) instance = this;
        else if (instance != this) Destroy(instance);

        // UI
        UI_KEY = GameObject.Find("UI_KEY");
        UI_CARROT = GameObject.Find("UI_CARROT");
        UI_Reuslt = GameObject.Find("UI_Reuslt");

        // Text
        UI_Reuslt_text = GameObject.Find("UI_Reuslt_text").GetComponent<Text>();
        UI_Regame_text = GameObject.Find("UI_Regame_text").GetComponent<Text>();

        // Button
        Btn_ReGame = GameObject.Find("Btn_ReGame").GetComponent<Button>();
        Btn_GoLobby = GameObject.Find("Btn_GoLobby").GetComponent<Button>();

        // Cursor
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Start()
    {
        // UI
        UI_KEY.SetActive(false);
        UI_CARROT.SetActive(false);
        UI_Reuslt.SetActive(false);

        // Button
        Btn_GoLobby.onClick.AddListener(() => Go_Lobby());
    }

    private void Update()
    {
        
    }

    // ---------------------------------------------------- Env -------------------------------------------------
    public void Result()
    {
        // Victory
        switch (Victoty_msg)
        {
            case "win":
                //
                Control_stop(); 

                // text

                UI_Regame_text.text = "다시 하기";
                UI_Reuslt_text.text = "승리~!";

                // func
                Btn_ReGame.onClick.AddListener(() => ReGame_start());
                break;

            case "lose":
                //
                Control_stop();

                // text
                UI_Regame_text.text = "다시 하기";
                UI_Reuslt_text.text = "패배";

                // func
                Btn_ReGame.onClick.AddListener(() => ReGame_start());
                break;

            case "pause":
                //
                Control_stop();

                // text
                UI_Regame_text.text = "마저 진행";
                UI_Reuslt_text.text = "일시정지";

                // func
                Btn_ReGame.onClick.AddListener(() => ReGame_in());
                break;
        }

        // UI
        UI_Reuslt.SetActive(true);

        // Cursor
        Cursor.visible = true;
    }

    public void ReGame_start()
    {
        // Cursor
        Cursor.visible = false;

        // Load
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //Control
        Control_start();
    }

    public void ReGame_in()
    {
        // Cursor
        Cursor.visible = false;

        // Load
        UI_Reuslt.SetActive(false);

        // Control
        Time.timeScale = 0f;
        Control_start();
    }

    public void Go_Lobby() 
    {
        // Cursor
        Cursor.visible = true;

        // Load
        SceneManager.LoadScene("Scenes/Lobby");

        // Control
        Control_start();
    }

    public void Control_stop()
    {
        Time.timeScale = 0f;
        Player.instance._mousespeed = 0f;
    }

    public void Control_start()
    {
        Time.timeScale = 1f;
        Player.instance._mousespeed = 7f;
    }
}
