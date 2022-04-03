using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public Button[] CellBtn;
    public Button PreviousBtn, NextBtn;
    public List<string> myList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18" };

    int currentPage = 1, maxPage, multiple;


    void Start()
    {
        // 최대페이지
        maxPage = (myList.Count % CellBtn.Length == 0) ? myList.Count / CellBtn.Length : myList.Count / CellBtn.Length + 1;

        // 이전, 다음버튼
        PreviousBtn.interactable = (currentPage <= 1) ? false : true;
        NextBtn.interactable = (currentPage >= maxPage) ? false : true;

        // 페이지에 맞는 리스트 대입
        multiple = (currentPage - 1) * CellBtn.Length;
        for (int i = 0; i < CellBtn.Length; i++)
        {
            CellBtn[i].interactable = (multiple + i < myList.Count) ? true : false;
            string _msg = (multiple + i < myList.Count) ? myList[multiple + i] + " 스테이지" : "";
            CellBtn[i].GetComponentInChildren<Text>().text = _msg;
            CellBtn[i].GetComponent<Button>().onClick.AddListener(() => LoadScence(_msg));
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void BtnClick(int num)
    {
        if (num == -2) --currentPage;
        else if (num == -1) ++currentPage;
        else print(myList[multiple + num]);

        Start();
    }

    public void LoadScence(string _msg)
    {
        string[] _Num = _msg.Split(' ');
        string Stage_Name = "Scenes/" + "Stage/" + "Stage" + _Num[0];
        SceneManager.LoadScene(Stage_Name);
    }


    [ContextMenu("리스트추가")]
    void ListAdd() { myList.Add("뚝배기"); Start(); }


    [ContextMenu("리스트제거")]
    void ListRemove() { myList.RemoveAt(0); Start(); }
}
