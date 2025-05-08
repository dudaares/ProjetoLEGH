using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.WSA;

public class ImportComentsHater : EditorWindow
{
    public TextAsset csvFile; // Referência ao arquivo CSV.
    public string nameObject;
    private string savePath = "Assets"; // Caminho padrão para salvar o asset.
    [SerializeField] private List<Sprite> images = new List<Sprite>(); // Lista persistente de sprites.
    public string spritesFolderPath = "Assets/Resources/Sprites";


#if UNITY_EDITOR
    // Método para carregar os sprites no modo Editor
    [ContextMenu("Carregar Sprites no Editor")]
    public void LoadSpritesInEditor()
    {
        if (string.IsNullOrEmpty(spritesFolderPath))
        {
            Debug.LogError("O caminho da pasta de sprites está vazio!");
            return;
        }

        // Busca todos os assets do tipo Sprite no caminho especificado.
        string[] guids = AssetDatabase.FindAssets("t:Sprite", new[] { spritesFolderPath });

        images = new List<Sprite>();

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
            if (sprite != null)
            {
                images.Add(sprite);
            }
        }
     
        Debug.Log($"Sprites carregados no Editor: {images.Count}");
    }
#endif

    [MenuItem("Tools/CSV To coments Minigame Hater")]
    public static void OpenWindow()
    {
        GetWindow<ImportComentsHater>("CSV To coments Minigame Hater");
    }

    private void OnGUI()
    {
        GUILayout.Label("CSV to Dialogue Scriptable", EditorStyles.boldLabel);

        // Campo para selecionar o arquivo CSV.
        csvFile = (TextAsset)EditorGUILayout.ObjectField("CSV File", csvFile, typeof(TextAsset), false);

        nameObject = EditorGUILayout.TextField("NameObject", nameObject);

        // Campo para definir o local de salvamento do ScriptableObject.
        savePath = EditorGUILayout.TextField("Save Path", savePath);


        spritesFolderPath = EditorGUILayout.TextField("Sprite Folder Path", spritesFolderPath);


        // Botão para dar reload na base de imagens
        if (GUILayout.Button("Reload Database sprites"))
        {
            ReloadSpriteDatabase();
        }
        GUILayout.Label($"Sprites carregados: {images.Count}");

        // Botão para criar o ScriptableObject.
        if (GUILayout.Button("Generate Dialogue Scriptable"))
        {
            if (csvFile == null)
            {
                Debug.LogError("Por favor, selecione um arquivo CSV.");
                return;
            }

            GenerateDialogueScriptable();
        }
    }


    private void ReloadSpriteDatabase()
    {
        if (string.IsNullOrEmpty(spritesFolderPath))
        {
            Debug.LogError("O caminho da pasta de sprites está vazio!");
            return;
        }

        // Debug log para verificar se o caminho foi reconhecido corretamente
        Debug.Log($"Tentando carregar os sprites de: {spritesFolderPath}");

        // Busca todos os assets do tipo Sprite no caminho especificado.
        string[] guids = AssetDatabase.FindAssets("t:Sprite", new[] { spritesFolderPath });

        images = new List<Sprite>();

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
            if (sprite != null)
            {
                images.Add(sprite);
                // Debug log para verificar se o sprite foi carregado
                Debug.Log($"Sprite carregado: {sprite.name}");
            }
            else
            {
                Debug.LogWarning($"Falha ao carregar o sprite de {assetPath}");
            }
        }

        Debug.Log($"Total de sprites carregados: {images.Count}");
    }
    private void GenerateDialogueScriptable()
    {
        // Verifica se o arquivo CSV está selecionado.
        if (csvFile == null)
        {
            Debug.LogError("Nenhum arquivo CSV foi selecionado.");
            return;
        }

        // Cria a pasta para salvar os ScriptableObjects, se não existir
        string folderPath = $"{savePath}";
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Lê e processa o arquivo CSV.
        string[] lines = csvFile.text.Split('\n'); // Divide o texto em linhas.
        int counter = 0; // Contador para nomear os arquivos

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue; // Ignora linhas vazias.

            string[] row = ParseCSVLine(line); // Analisa a linha do CSV.
            if (row.Length >= 4) // Garante que existam pelo menos x colunas.
            {
                // Cria uma nova instância do DialogueScriptable para cada linha
                HaterMiniGameScriptable dialogue = ScriptableObject.CreateInstance<HaterMiniGameScriptable>();

                // Adiciona dados ao ScriptableObject
                dialogue.nickName = row[0]; // Coluna 1.
                dialogue.textComents = row[1];  // Coluna 2.

                if (row[2] == "report")
                {
                    dialogue.isHater = true;
                }
                else
                {
                    dialogue.isHater = false;
                }

                // Verifica a lista de imagens antes de tentar adicionar os sprites
                if (images == null || images.Count == 0)
                {
                    Debug.LogWarning("A lista de imagens está vazia ou não foi carregada.");
                }
                else
                {

                    // Adiciona o sprite do player, se encontrado
                    Sprite sprite = images.Find(image => image.name.Trim() == row[3].Trim());

                    Debug.Log(sprite);

                    if (sprite != null)
                    {
                        dialogue.imageAccount = sprite;
                        Debug.Log($"Sprite para o Player '{row[3]}'encontrado.");
                    }
                    else
                    {
                        Debug.LogWarning($"Sprite para o Player '{row[3]}' não encontrado.");
                        dialogue.imageAccount = null;
                    }
                }

                // Define o caminho para salvar o ScriptableObject individual
                string assetName = $"{nameObject}_{counter:D3}";
                // Remover caracteres inválidos para nomes de arquivo
                assetName = string.Join("_", assetName.Split(Path.GetInvalidFileNameChars()));

                string assetPath = $"{folderPath}/{assetName}.asset";

                // Salva o ScriptableObject no caminho especificado.
                AssetDatabase.CreateAsset(dialogue, assetPath);
                counter++;
            }
            else
            {
                Debug.LogWarning($"Linha ignorada (faltando colunas): {line}");
            }
        }

        // Salva todos os assets criados
        AssetDatabase.SaveAssets();
        Debug.Log($"{counter} Dialogue Scriptables criados com sucesso em: {folderPath}");
    }

    // Método para analisar uma linha do CSV corretamente.
    private string[] ParseCSVLine(string line)
    {
        List<string> result = new List<string>();
        bool insideQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == '"') // Alterna o estado das aspas.
            {
                insideQuotes = !insideQuotes;
            }
            else if (c == ',' && !insideQuotes) // Divide a coluna fora das aspas.
            {
                result.Add(current);
                current = "";
            }
            else
            {
                current += c; // Adiciona o caractere atual à coluna.
            }
        }

        // Adiciona a última coluna.
        result.Add(current);

        return result.ToArray();
    }

}