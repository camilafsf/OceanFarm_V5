using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Resolution : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    private List<Vector2Int> resolutions;

    void Start()
    {
        // Define as resoluções disponíveis
        resolutions = new List<Vector2Int>
        {
            new Vector2Int(800, 600),
            new Vector2Int(1024, 768),
            new Vector2Int(1280, 720),
            new Vector2Int(1366, 768),
            new Vector2Int(1600, 900),
            new Vector2Int(1920, 1080)
        };

        // Define as opções do TMP_Dropdown
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (Vector2Int resolution in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData($"{resolution.x}x{resolution.y}");
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);

        // Define a resolução atual do jogo
        Vector2Int currentResolution = new Vector2Int(Screen.width, Screen.height);
        int currentIndex = resolutions.IndexOf(currentResolution);

        // Se não encontrar a resolução atual, adiciona ela como uma nova opção
        if (currentIndex == -1)
        {
            resolutions.Add(currentResolution);
            currentIndex = resolutions.Count - 1;
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData($"{currentResolution.x}x{currentResolution.y}");
            resolutionDropdown.options.Add(option);
        }

        // Seleciona a opção correspondente à resolução atual
        resolutionDropdown.value = currentIndex;

        // Adiciona um listener para o TMP_Dropdown
        resolutionDropdown.onValueChanged.AddListener(delegate
        {
            OnResolutionChanged(resolutionDropdown.value);
        });
    }

    void OnResolutionChanged(int index)
    {
        // Obtém a resolução selecionada e define a resolução do jogo
        Vector2Int selectedResolution = resolutions[index];
        Screen.SetResolution(selectedResolution.x, selectedResolution.y, Screen.fullScreen);

        // Salva a resolução selecionada e a opção no PlayerPrefs
        PlayerPrefs.SetInt("ResolutionWidth", selectedResolution.x);
        PlayerPrefs.SetInt("ResolutionHeight", selectedResolution.y);
        PlayerPrefs.SetInt("ResolutionOption", index);
        PlayerPrefs.Save();

    }

    void OnDisable()
    {
        // Salva a resolução selecionada e a opção no PlayerPrefs quando o jogo é fechado ou quando se muda de cena
        Vector2Int selectedResolution = resolutions[resolutionDropdown.value];
        PlayerPrefs.SetInt("ResolutionWidth", selectedResolution.x);
        PlayerPrefs.SetInt("ResolutionHeight", selectedResolution.y);
        PlayerPrefs.SetInt("ResolutionOption", resolutionDropdown.value);
        PlayerPrefs.Save();
    }
}
