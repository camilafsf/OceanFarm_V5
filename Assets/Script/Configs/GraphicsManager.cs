using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GraphicsManager : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;

    // Nomes dos níveis de qualidade
    private string[] qualityNames = { "Very Low", "Low", "Medium", "High", "Very High", "Ultra" };

    void Start()
    {
        // Define as opções do dropdown de acordo com os nomes dos níveis de qualidade
        graphicsDropdown.ClearOptions();
        graphicsDropdown.AddOptions(new List<string>(qualityNames));

        // Define o valor do dropdown de acordo com a configuração salva
        graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", QualitySettings.GetQualityLevel());

        // Adiciona um listener para o evento de mudança de seleção do dropdown
        graphicsDropdown.onValueChanged.AddListener(delegate { OnGraphicsDropdownChange(); });
    }

    public void OnGraphicsDropdownChange()
    {
        // Obtém o valor atual do dropdown
        int graphicsQuality = graphicsDropdown.value;

        // Define o nível de qualidade de acordo com o valor do dropdown
        QualitySettings.SetQualityLevel(graphicsQuality, true);

        // Salva o valor do dropdown para ser recuperado posteriormente
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        PlayerPrefs.Save();
    }
}
