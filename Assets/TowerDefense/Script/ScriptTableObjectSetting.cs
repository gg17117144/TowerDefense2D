using TowerDefense.Script.ScriptObject.Script;
using UnityEditor;
using UnityEngine;

namespace TowerDefense.Script
{
    public class ScriptObjectEditor : EditorWindow
    {
        private bool _heroSoFoldout = true;
        private bool _enemySoFoldout = true;
        private bool _defenseSettingsFoldout = true;
        private Vector2 _scrollPosition;
        
        [MenuItem("TowerDefense/ScriptObject Editor")]
        private static void OpenWindow()
        {
            GetWindow<ScriptObjectEditor>("ScriptObject Editor");
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("英雄設定", EditorStyles.boldLabel);
            _heroSoFoldout = EditorGUILayout.Foldout(_heroSoFoldout, "英雄設定");
            if (_heroSoFoldout)
            {
                DrawScriptableObjectGroup<HeroSo>();
            }
            
            EditorGUILayout.LabelField("敵人設定", EditorStyles.boldLabel);
            _enemySoFoldout = EditorGUILayout.Foldout(_enemySoFoldout, "敵人設定");
            if (_enemySoFoldout)
            {
                DrawScriptableObjectGroup<EnemySo>();
            }

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("防禦機制設定", EditorStyles.boldLabel);
            _defenseSettingsFoldout = EditorGUILayout.Foldout(_defenseSettingsFoldout, "防禦機制設定");
            if (_defenseSettingsFoldout)
            {
                DrawScriptableObjectGroup<DefenseMechanismSo>();
            }

            EditorGUILayout.Space();

            // 按下按鈕新增新的HeroSo
            if (GUILayout.Button("新增英雄設定"))
            {
                CreateNewSetting<HeroSo>();
            }
            
            // 按下按鈕新增新的EnemySo
            if (GUILayout.Button("新增敵人設定"))
            {
                CreateNewSetting<EnemySo>();
            }

            // 按下按鈕新增新的DefenseMechanismSo
            if (GUILayout.Button("新增防禦機制設定"))
            {
                CreateNewSetting<DefenseMechanismSo>();
            }
        }
        
        private void DrawScriptableObjectGroup<T>() where T : ScriptableObject
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
            var settings = Resources.LoadAll<T>("");
            foreach (var setting in settings)
            {
                DrawSetting(setting);
            }
            EditorGUILayout.EndScrollView();
        }


        private void DrawSetting(ScriptableObject setting)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUI.indentLevel++;

            if (setting is HeroSo)
            {
                var defenseSetting = setting as HeroSo;
            }
            else if (setting is EnemySo)
            {
                var defenseSetting = setting as EnemySo;
            }
            else if (setting is DefenseMechanismSo)
            {
                var defenseSetting = setting as DefenseMechanismSo;
            }
            
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }

        private void CreateNewSetting<T>() where T : ScriptableObject, new()
        {
            // 創建一個新的ScriptableObject資源
            var newSetting = ScriptableObject.CreateInstance<T>();

            // 在Project視窗中創建資源
            string path = EditorUtility.SaveFilePanelInProject("新增設定", "NewSetting", "asset", "請選擇設定的儲存位置");
            if (path.Length != 0)
            {
                // 將路徑轉換為相對於 "Assets" 資料夾的路徑
                string relativePath = path.Replace(Application.dataPath, "Assets");
                AssetDatabase.CreateAsset(newSetting, relativePath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
        
        
    }
}
