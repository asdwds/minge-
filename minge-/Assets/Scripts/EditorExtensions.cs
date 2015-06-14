using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using Game;

namespace EditorExtensions
{
    public class CreateStageWindow : EditorWindow
    {
        [MenuItem("Window/CreateStage")]
        static void Init()
        {
            CreateStageWindow window = (CreateStageWindow)GetWindow(typeof(CreateStageWindow));
            window.title = "ステージ生成";
        }

        static Rect labelRect = new Rect(10, 10, 100, 20);
        static Rect inputRect = new Rect(10, 30, 200, 500);
        static Rect buttonRect = new Rect(10, 70, 100, 30);
        string stageName = "";
        int timelimit = 0;
        int slotcount = 5;
        Stage.Region region = new Stage.Region();

        void OnGUI()
        {
            GUILayout.BeginVertical();

            GUILayout.Label("ステージの名前", EditorStyles.boldLabel);
            stageName = GUILayout.TextArea(stageName, EditorStyles.textArea);

            GUILayout.Label("制限時間(整数秒)", EditorStyles.boldLabel);
            timelimit = Convert.ToInt32(GUILayout.TextArea(timelimit.ToString(), EditorStyles.textArea));

            GUILayout.Label("アイテムスロット数", EditorStyles.boldLabel);
            slotcount = Convert.ToInt32(GUILayout.TextArea(slotcount.ToString(), EditorStyles.textArea));

            GUILayout.Label("ステージの範囲", EditorStyles.boldLabel);
            GUILayout.Label("(左端、右端)", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            region.Left = Convert.ToInt32(GUILayout.TextArea(region.Left.ToString(), EditorStyles.textArea));
            region.Right = Convert.ToInt32(GUILayout.TextArea(region.Right.ToString(), EditorStyles.textArea));
            GUILayout.EndHorizontal();

            GUILayout.Label("(下端、上端)", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            region.Bottom = Convert.ToInt32(GUILayout.TextArea(region.Bottom.ToString(), EditorStyles.textArea));
            region.Top = Convert.ToInt32(GUILayout.TextArea(region.Top.ToString(), EditorStyles.textArea));
            GUILayout.EndHorizontal();

            GUILayout.Label("高さ", EditorStyles.boldLabel);
            region.Height = Convert.ToInt32(GUILayout.TextArea(region.Height.ToString(), EditorStyles.textArea));

            if (GUILayout.Button( "ステージを保存"))
            {
                Stage.Save(stageName, timelimit, slotcount, region);   
            }

            GUILayout.EndVertical();

            //GUI.Label(labelRect, "ステージの名前", EditorStyles.boldLabel);
            //GUI.BeginGroup(inputRect);
            //stageName = GUI.TextArea(inputRect, stageName, EditorStyles.textArea);
        }
    }
}