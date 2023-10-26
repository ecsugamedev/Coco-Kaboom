using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    public Controls playerControls;

    private void Awake()
    {
        playerControls = new Controls();
    }

    // Enables player controls
    private void OnEnable()
    {
        playerControls.Enable();
    }

    // Disables player controls
    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (playerControls.Restart.Pause.WasPressedThisFrame()) // You can change the key as needed
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Freeze the game
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume normal time
        pauseMenuUI.SetActive(false);
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }

    public void Leaderboard()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

