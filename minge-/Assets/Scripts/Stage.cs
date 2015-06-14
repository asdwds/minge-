using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using LitJson;
using System.Text.RegularExpressions;

namespace Game
{
    public class Stage
    {
        /// <summary>
        /// ステージの制限時間（秒）
        /// </summary>
        public int TimeLimit;

        /// <summary>
        /// アイテムスロットの数
        /// </summary>
        public int SlotCount;

        public Region StageRegion;

        public List<Player> Players;
        public List<Terrain> Terrains;
        public List<Gimmick> Gimmicks;
        public List<Flag> Flags;
        public List<Item> Items;

        public Stage()
        {
            TimeLimit = 60;
            SlotCount = 5;

            Players = new List<Player>();
            Terrains = new List<Terrain>();
            Gimmicks = new List<Gimmick>();
            Flags = new List<Flag>();
            Items = new List<Item>();
        }

        public Stage(int time, int slotcount)
            :this()
        {
            TimeLimit = time;
            SlotCount = slotcount;
        }

        #region Stageの構造物たち

        /// <summary>
        /// ステージ中にあるオブジェクトを表す基底クラス
        /// </summary>
        public abstract class StageObject
        {
            public double PosX;
            public double PosY;
            public double PosZ;

            public double RotX;
            public double RotY;
            public double RotZ;
            public double RotW;

            public string PrefabName;

            public StageObject()
            {
                PosX = 0;
                PosY = 0;
                PosZ = 0;
                RotX = 0;
                RotY = 0;
                RotZ = 0;
                RotW = 0;
                PrefabName = "";
            }

            public StageObject(GameObject g)
            {
                Transform tf = g.transform;
                PosX = tf.position.x;
                PosY = tf.position.y;
                PosZ = tf.position.z;
                RotX = tf.rotation.x;
                RotY = tf.rotation.y;
                RotZ = tf.rotation.z;
                RotW = tf.rotation.w;
                PrefabName = g.name.Replace("(Clone)", "");
                PrefabName = Regex.Replace(PrefabName, @"[\d]", "");
            }

            public StageObject(JsonNode json)
            {

                PosX = json["PosX"].Get<double>();
                PosY = json["PosY"].Get<double>();
                PosZ = json["PosZ"].Get<double>();
                RotX = json["RotX"].Get<double>();
                RotY = json["RotY"].Get<double>();
                RotZ = json["RotZ"].Get<double>();
                RotW = json["RotW"].Get<double>();
                PrefabName = json["PrefabName"].Get<string>();
            }

            public GameObject Load()
            {
                try
                {
                    GameObject prefab = Resources.Load<GameObject>("Prefab/" + GetType().Name + "/" + PrefabName);
                    GameObject g = Object.Instantiate(prefab, new Vector3((float)PosX, (float)PosY, (float)PosZ), new Quaternion((float)RotX, (float)RotY, (float)RotZ, (float)RotW)) as GameObject;
                    return g;
                }
                catch
                {
                    Debug.Log("Load失敗(" + GetType().Name + ", " + PrefabName + ")");
                    return null;
                }
            }
        }

        public class Player : StageObject
        {
            public Player()
                :base()
            {
            }

            public Player(GameObject g)
                :base(g)
            {
            }

            public Player(JsonNode json)
                :base(json)
            {
            }

            new public GameObject Load()
            {
                GameObject prefab = Resources.Load<GameObject>("Prefab/Player");
                Vector3 pos = new Vector3((float)PosX, (float)PosY, (float)PosZ);
                Quaternion rot = new Quaternion((float)RotX, (float)RotY, (float)RotZ, (float)RotW);
                GameObject g = Object.Instantiate(prefab, pos, rot) as GameObject;
                return g;
            }
        }

        /// <summary>
        /// ステージ中の地形用クラス
        /// </summary>
        public class Terrain : StageObject
        {
            public Terrain()
                :base()
            {
            }

            public Terrain(GameObject g)
                :base(g)
            {
            }

            public Terrain(JsonNode json)
                :base(json)
            {
            }

            new public GameObject Load()
            {
                GameObject g = base.Load();
                return g;
            }
        }

        /// <summary>
        /// ステージ中のギミック用クラス
        /// </summary>
        public class Gimmick : StageObject
        {
            public Gimmick()
                :base()
            {
            }

            public Gimmick(GameObject g)
                :base(g)
            {
            }

            public Gimmick(JsonNode json)
                :base(json)
            {
            }

            new public GameObject Load()
            {
                GameObject g = base.Load();
                return g;
            }
        }

        /// <summary>
        /// ステージ中のフラッグ用クラス
        /// </summary>
        public class Flag : StageObject
        {
            public Flag()
                :base()
            {
            }

            public Flag(GameObject g)
                :base(g)
            {
            }

            public Flag(JsonNode json)
                :base(json)
            {
            }

            new public GameObject Load()
            {
                GameObject g = base.Load();
                return g;
            }
        }

        /// <summary>
        /// ステージ中の固定アイテム用クラス
        /// </summary>
        public class Item : StageObject
        {
            public Item()
                :base()
            {
            }

            public Item(GameObject g)
                :base(g)
            {
            }

            public Item(JsonNode json)
                :base(json)
            {
            }

            new public GameObject Load()
            {
                GameObject g = base.Load();
                return g;
            }
        }

        [System.Serializable]
        public class Region
        {
            public int Left;
            public int Right;
            public int Bottom;
            public int Top;
            public int Height;

            public Region()
            {
                Left = 0;
                Right = 200;
                Bottom = 0;
                Top = 200;

                Height = 100;
            }
        }

        #endregion

        public static void Save(string stagename, int limit, int slotcount, Region region)
        {
            Stage stage = new Stage();

            stage.TimeLimit = limit;
            stage.SlotCount = slotcount;
            stage.StageRegion = region;

            foreach(var g in GameObject.FindGameObjectsWithTag("Player"))
            {
                Player player = new Player(g);
                stage.Players.Add(player);
            }

            foreach(var g in GameObject.FindGameObjectsWithTag("Terrain"))
            {
                Terrain terrain = new Terrain(g);
                stage.Terrains.Add(terrain);
            }

            foreach(var g in GameObject.FindGameObjectsWithTag("Gimmick"))
            {
                Gimmick gimmick = new Gimmick(g);
                stage.Gimmicks.Add(gimmick);
            }

            foreach(var g in GameObject.FindGameObjectsWithTag("Flag"))
            {
                Flag flag = new Flag(g);
                stage.Flags.Add(flag);
            }

            foreach(var g in GameObject.FindGameObjectsWithTag("Item"))
            {
                Item item = new Item(g);
                stage.Items.Add(item);
            }

            string jsontext = JsonMapper.ToJson(stage);

            StreamWriter writer = new StreamWriter(Application.dataPath + "/Resources/StageJson/" + stagename + ".json");
            writer.Write(jsontext);
            writer.Close();

            Debug.Log("ステージ作った（ステージ名：" + stagename + ")");

            Load(stagename);
        }

        public static void Load(string stagename)
        {
            TextAsset asset = Resources.Load("StageJson/" + stagename) as TextAsset;
            if(asset == null)
            {
                Debug.Log("ステージ読み込めなかった（ステージ名：" + stagename + ")");
                return;
            }

            JsonNode json = JsonNode.Parse(asset.text);

            GameSetting.TimeLimit = (int)json["TimeLimit"].Get<long>();
            GameSetting.SlotCount = (int)json["SlotCount"].Get<long>();
            GameSetting.StageName = stagename;

            Transform parent;

            parent = (GameObject.Find("/Players") as GameObject).transform;
            foreach (var item in json["Players"])
            {
                GameObject g = new Player(item).Load();
                if (g != null) g.transform.SetParent(parent);
            }

            parent = (GameObject.Find("/Terrains") as GameObject).transform;
            foreach(var item in json["Terrains"])
            {
                GameObject g = new Terrain(item).Load();
                if (g != null) g.transform.SetParent(parent);
            }

            parent = (GameObject.Find("/Gimmicks") as GameObject).transform;
            foreach (var item in json["Gimmicks"])
            {
                GameObject g = new Gimmick(item).Load();
                if (g != null) g.transform.SetParent(parent);
            }

            parent = (GameObject.Find("/Flags") as GameObject).transform;
            foreach (var item in json["Flags"])
            {
                GameObject g = new Flag(item).Load();
                if (g != null) g.transform.SetParent(parent);
            }

            parent = (GameObject.Find("/Items") as GameObject).transform;
            foreach (var item in json["Items"])
            {
                GameObject g = new Item(item).Load();
                if (g != null) g.transform.SetParent(parent);
            }
        }
    }
}
