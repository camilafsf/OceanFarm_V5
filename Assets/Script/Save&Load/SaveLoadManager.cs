using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] private string saveFileName = "savedata.dat";

    public void SaveData()
    {
        // Criar um objeto de dados a ser salvo
        SaveData data = new SaveData();
        // Aqui você deve preencher as informações do objeto de dados com os dados que deseja salvar.

        // Criar um formatter binário
        BinaryFormatter formatter = new BinaryFormatter();

        // Criar um arquivo para salvar os dados
        string saveFilePath = Application.persistentDataPath + "/" + saveFileName;
        FileStream fileStream = new FileStream(saveFilePath, FileMode.Create);

        // Serializar os dados e salvá-los no arquivo
        formatter.Serialize(fileStream, data);

        // Fechar o arquivo
        fileStream.Close();

        Debug.Log("Dados salvos em: " + saveFilePath);
    }

    public void LoadData()
    {
        // Verificar se o arquivo de dados existe
        string saveFilePath = Application.persistentDataPath + "/" + saveFileName;
        if (File.Exists(saveFilePath))
        {
            // Criar um formatter binário
            BinaryFormatter formatter = new BinaryFormatter();

            // Abrir o arquivo de dados
            FileStream fileStream = new FileStream(saveFilePath, FileMode.Open);

            // Desserializar os dados do arquivo
            SaveData data = formatter.Deserialize(fileStream) as SaveData;

            // Fechar o arquivo
            fileStream.Close();

            // Aqui você deve carregar os dados do objeto de dados no seu jogo.

            Debug.Log("Dados carregados de: " + saveFilePath);
        }
        else
        {
            Debug.Log("Não há dados salvos.");
        }
    }
}

// Objeto de dados para salvar
[System.Serializable]
public class SaveData
{
    // Aqui você pode adicionar variáveis ​​que deseja salvar.
}

