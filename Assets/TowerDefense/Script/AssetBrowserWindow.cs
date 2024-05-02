#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace TowerDefense.Script
{
    public class AssetBrowserWindow : EditorWindow
    {
        private const string FolderPath = "Assets/TowerDefense/Script/ScriptObject"; // 起始資料夾路徑
        private string[] _assetPaths;
        private string _assetRelativePath;

        private Vector2 _leftScrollPosition;
        private Vector2 _rightScrollPosition;

        [MenuItem("Window/Data Setting")]
        public static void ShowWindow()
        {
            GetWindow<AssetBrowserWindow>("Data Setting");
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();

            // 左側面板
            EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(position.width * 0.3f));
            DrawLeftPanel();
            EditorGUILayout.EndVertical();

            // 右側面板
            EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(position.width * 0.7f));
            _rightScrollPosition = EditorGUILayout.BeginScrollView(_rightScrollPosition);
            DrawRightPanel();
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal();
        }

        private void DrawLeftPanel()
        {
            EditorGUILayout.LabelField("檔案", EditorStyles.boldLabel);

            _leftScrollPosition = EditorGUILayout.BeginScrollView(_leftScrollPosition);

            _assetPaths = Directory.GetFiles(FolderPath, "*.asset", SearchOption.AllDirectories);

            foreach (var assetPath in _assetPaths)
            {
                var cleanedFileName = GetCleanedFileName(assetPath);
                var relativePath = GetRelativePath(assetPath);
                if (GUILayout.Button($"{cleanedFileName}"))
                {
                    _assetRelativePath = relativePath;
                }
            }

            EditorGUILayout.EndScrollView();
        }

        private void DrawRightPanel()
        {
            EditorGUILayout.LabelField("匹配的資產:", EditorStyles.boldLabel);

            DisplayAssetInfo(_assetRelativePath);
        }

        private void DisplayAssetInfo(string assetRelativePath)
        {
            if (string.IsNullOrEmpty(assetRelativePath))
                return;

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

        static string GetCleanedFileName(string filePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string[] parts = fileName.Split('/');
            return parts[^1];
        }
    }
}
#endif