using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private bool isPauseMenu = false;
    [Tooltip("Canvas GameObject\nOnly needed if being used for the pause menu")]
    [SerializeField] private GameObject pauseMenu;
    [Tooltip("Only needed if being used for the pause menu")]
    [SerializeField] private KeyCode PauseButton = KeyCode.Escape;


    public void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    // Assumes main menu is scene index 0
    public void ExitLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void Update()
    {
        if (isPauseMenu)
        {
            if (Input.GetKeyDown(PauseButton))
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        pauseMenu.SetActive(pauseMenu.activeInHierarchy == true ? false : true);
    }
}
