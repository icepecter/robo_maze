using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    Text _subject;
    string _subjecttext;

    private void Awake()
    {
        _subjecttext = "ESCAPE FROM A ZOMBIE";
        _subject = GameObject.Find("3_t_Subject").GetComponent<Text>();
    }

    private void Start()
    {
        StartCoroutine(_typing());
    }

    IEnumerator _typing()
    {
        for (int i = 0; i <= _subjecttext.Length; i++) 
        {
            _subject.text = _subjecttext.Substring(0, i);
            yield return new WaitForSeconds(0.1f);         
        }
    }

    public void Go_Lobby() => SceneManager.LoadScene("Lobby");
}


