using UnityEngine;
using UnityEditor;
using System.Collections;
using Game;

namespace EditorExtensions
{
    public class CreateStageWindow : EditorWindow
    {
        [MenuItem("Window/CreateStage")]
        static void Init()
        {
            CreateStageWindow window = (CreateStageWindow)EditorWindow.GetWindow(typeof(CreateStageWindow));
            window.title = "ステージ生成";
        }

        static Rect labelRect = new Rect(10, 10, 100, 20);
        static Rect textRect = new Rect(10, 30, 200, 20);
        static Rect buttonRect = new Rect(10, 70, 100, 30);
        string StageName = "";

        void OnGUI()
        {
            GUI.Label(labelRect, "ステージの名前", EditorStyles.boldLabel);
            StageName = GUI.TextArea(textRect, StageName, EditorStyles.textArea);
            if (GUI.Button(buttonRect, "ステージを保存", EditorStyles.miniButton))
            {
                Stage.Save(StageName);   
            }
        }
    }
}