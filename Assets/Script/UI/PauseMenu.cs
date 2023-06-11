using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button Resume;

    private bool isPaused = false;

    private void Start()
    {
        // Esconder o menu de pausa no início
        pauseMenuUI.SetActive(false);

        // Adicionar um listener ao botão de "pausa/despausa"
        pauseButton.onClick.AddListener(TogglePause);
        Resume.onClick.AddListener(TogglePause);
    }

    private void TogglePause()
    {
        if (isPaused)
        {

            Pause.pause.UnPaused();
            // Esconder o menu de pausa
            pauseMenuUI.SetActive(false);

            // Definir a flag de pausa como falsa
            isPaused = false;
        }
        else
        {
            // Pausar o tempo do jogo
            Pause.pause.Paused();

            // Mostrar o menu de pausa
            pauseMenuUI.SetActive(true);

            // Definir a flag de pausa como verdadeira
            isPaused = true;
        }
    }
}
