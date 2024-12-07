using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameInput;

    private void Start()
    {
        NameInput.onSubmit.AddListener(NewNameEntered);
        NameInput.onEndEdit.AddListener(NewNameEntered);
    }

    public void NewNameEntered(string name)
    {
        PlayerDataHandler.Instance.PlayerName = name;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
