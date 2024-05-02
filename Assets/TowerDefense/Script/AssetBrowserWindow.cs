using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBrowserWindow : EditorWindow
{
    private string folderPath = "Assets/TowerDefense/Script/ScriptObject"; // 起始資料夾路徑
    private string[] assetPaths;
    private bool[] showAssetInfo; // 每個.asset檔案的Toggle狀態
    private Vector2 scrollPosition; // 捲動位置
    private string assetRelativePath;

    [MenuItem("Window/資產瀏覽器")] // 將菜單改為繁體中文
    public static void ShowWindow()
    {
        GetWindow<AssetBrowserWindow>("資產瀏覽器"); // 將窗口標題改為繁體中文
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        DrawLeftPanel(); // 左邊選單
        DrawRightPanel(); // 右邊顯示.asset檔案
        EditorGUILayout.EndHorizontal();
    }

    private void DrawLeftPanel()
    {
        EditorGUILayout.BeginVertical(GUILayout.Width(position.width * 0.2f));
        
        GUILayout.Label("檔案", EditorStyles.boldLabel); // 將標籤改為繁體中文
        
        assetPaths = Directory.GetFiles(folderPath, "*.asset", SearchOption.AllDirectories);
        
        foreach (var assetPath in assetPaths)
        {
            var cleanedFileName = GetCleanedFileName(assetPath);
            var relativePath = GetRelativePath(assetPath);
            if (GUILayout.Button($"{cleanedFileName}"))
            {
                assetRelativePath = relativePath;
            }
        }
        
        EditorGUILayout.EndVertical();
    }
    
    private void DrawRightPanel()
    {
        EditorGUILayout.BeginVertical(GUILayout.Width(position.width * 0.8f));

        // GUILayout.Label("匹配的資產:", EditorStyles.boldLabel); // 將標籤改為繁體中文
        //
        // // 初始化 Toggle 狀態數組
        // if (showAssetInfo == null || showAssetInfo.Length != assetPaths.Length)
        // {
        //     showAssetInfo = new bool[assetPaths.Length];
        // }
        //
        // scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        //
        // for (int i = 0; i < assetPaths.Length; i++)
        // {
        //     string assetRelativePath = GetRelativePath(assetPaths[i]);
        //     showAssetInfo[i] = EditorGUILayout.ToggleLeft(assetRelativePath, showAssetInfo[i]);
        //
        //     if (showAssetInfo[i])
        //     {
        //         DisplayAssetInfo(assetRelativePath);
        //         GUILayout.Space(10);
        //     }
        // }
        
        DisplayAssetInfo(assetRelativePath);
        // DisplayAssetInfo("Assets/TowerDefense/Script/ScriptObject/EnemySo/Pirate_02.asset");

        EditorGUILayout.EndScrollView();

        EditorGUILayout.EndVertical();
    }

    private void DisplayAssetInfo(string assetRelativePath)
    {
        Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetRelativePath);
        if (asset != null)
        {
            SerializedObject serializedObject = new SerializedObject(asset);
            SerializedProperty property = serializedObject.GetIterator();

            while (property.NextVisible(true))
            {
                EditorGUILayout.PropertyField(property, true);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

    private string GetRelativePath(string fullPath)
    {
        return fullPath.Replace(Application.dataPath, "Assets");
    }
    
    //做字串處理
    static string GetCleanedFileName(string filePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string[] parts = fileName.Split('/'); // 假設檔名可能包含 '/' 字元
        return parts[parts.Length - 1]; // 返回分割後的最後一個部分
    }
}
