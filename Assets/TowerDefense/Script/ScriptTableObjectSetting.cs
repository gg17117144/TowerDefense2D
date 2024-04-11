using TowerDefense.Script.ScriptObject.Script;
using UnityEditor;
using UnityEngine;

namespace CharacterAI
{
    public class CharacterEditor : EditorWindow
    {
        private bool HeroSoFoldout = true;
        private bool EnemySoFoldout = true;
        private bool defenseSettingsFoldout = true;
        private Vector2 scrollPosition;

        [MenuItem("WOWWOW/Character Editor")]
        private static void OpenWindow()
        {
            GetWindow<CharacterEditor>("Character Editor");
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("英雄設定", EditorStyles.boldLabel);
            HeroSoFoldout = EditorGUILayout.Foldout(HeroSoFoldout, "英雄設定");
            if (HeroSoFoldout)
            {
                DrawScriptableObjectGroup<HeroSo>();
            }
            
            EditorGUILayout.LabelField("敵人設定", EditorStyles.boldLabel);
            EnemySoFoldout = EditorGUILayout.Foldout(EnemySoFoldout, "敵人設定");
            if (EnemySoFoldout)
            {
                DrawScriptableObjectGroup<EnemySo>();
            }

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("防禦機制設定", EditorStyles.boldLabel);
            defenseSettingsFoldout = EditorGUILayout.Foldout(defenseSettingsFoldout, "防禦機制設定");
            if (defenseSettingsFoldout)
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
            var settings = Resources.LoadAll<T>("");
            foreach (var setting in settings)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUI.indentLevel++;

                // Display foldout for each ScriptableObject with its name
                EditorGUILayout.BeginHorizontal();
                bool foldout = EditorGUILayout.Foldout(true, setting.name);
                EditorGUILayout.EndHorizontal();

                // If foldout is true, draw the setting
                if (foldout)
                {
                    DrawSetting(setting);
                }

                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
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
