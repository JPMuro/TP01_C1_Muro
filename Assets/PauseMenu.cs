using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject creditsPanel;
    public GameObject exitPanel;

    [Header("Player Settings")]
    public Slider sliderPlayer1;
    public Slider sliderPlayer2;
    public Text valueTextP1;
    public Text valueTextP2;

    [Header("Players")]
    public Movement player1;
    public Movement player2;

    private bool isPaused = false;

    void Start()
    {
        // Inicializar textos de sliders
        sliderPlayer1.onValueChanged.AddListener(UpdatePlayer1Speed);
        sliderPlayer2.onValueChanged.AddListener(UpdatePlayer2Speed);

        valueTextP1.text = sliderPlayer1.value.ToString("F1");
        valueTextP2.text = sliderPlayer2.value.ToString("F1");

        // Asegurar que empiece en MainPanel
        ShowMainPanel();
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Detiene el tiempo
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Restaura el tiempo
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ShowMainPanel()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ShowSettingsPanel()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void ShowCreditsPanel()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para editor
#else
        Application.Quit(); // Para build
#endif
    }

    public void UpdatePlayer1Speed(float value)
    {
        valueTextP1.text = value.ToString("F1");
        if (player1 != null) player1.speed = value;
    }

    public void UpdatePlayer2Speed(float value)
    {
        valueTextP2.text = value.ToString("F1");
        if (player2 != null) player2.speed = value;
    }
}