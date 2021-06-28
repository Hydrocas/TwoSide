using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class S_MenuManager : MonoBehaviour
{
    [SerializeField] private MusicManager musicManager;

    public void Awake()
    {
        musicManager.Init();
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        musicManager.DaySoundState();
        SceneManager.LoadScene(sceneName);

    }

    public void SelectButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(button);
    }
}

