using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using LitJson;
namespace Game
{
    public class Stage
    {
        public List<Terrain> Terrains;
        public List<Gimmick> Gimmicks;
        public List<Flag> Flags;
        public List<Item> Items;

        public Stage()
        {
        }

        #region Stageの構造物たち

        /// <summary>
        /// ステージ中の地形用クラス
        /// </summary>
        public class Terrain
        {
            public double PosX;
            public double PosY;
            public double PosZ;

            public double RotX;
            public double RotY;
            public double RotZ;
            public double RotW;

            public string PrefabName;

            public Terrain()
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

            public Terrain(GameObject g)
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
            }

            public GameObject Load()
            {
                GameObject prefab = Resources.Load<GameObject>("/Prefab/Terrain/" + PrefabName);
                GameObject g = Object.Instantiate(prefab, new Vector3((float)PosX, (float)PosY, (float)PosZ), new Quaternion((float)RotX, (float)RotY, (float)RotZ, (float)RotW)) as GameObject;
                return g;
            }
        }

        /// <summary>
        /// ステージ中のギミック用クラス
        /// </summary>
        public class Gimmick
        {
            public double PosX;
            public double PosY;
            public double PosZ;

            public double RotX;
            public double RotY;
            public double RotZ;
            public double RotW;

            public string PrefabName;

            public Gimmick()
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
            
            public Gimmick(GameObject g)
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
            }

            public GameObject Load()
            {
                GameObject prefab = Resources.Load<GameObject>("/Prefab/Gimmick/" + PrefabName);
                GameObject g = Object.Instantiate(prefab, new Vector3((float)PosX, (float)PosY, (float)PosZ), new Quaternion((float)RotX, (float)RotY, (float)RotZ, (float)RotW)) as GameObject;
                return g;
            }
        }

        /// <summary>
        /// ステージ中のフラッグ用クラス
        /// </summary>
        public class Flag
        {
            public double PosX;
            public double PosY;
            public double PosZ;

            public double RotX;
            public double RotY;
            public double RotZ;
            public double RotW;

            public string PrefabName;

            public Flag()
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

            public Flag(GameObject g)
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
            }

            public GameObject Load()
            {
                GameObject prefab = Resources.Load<GameObject>("/Prefab/Flag/" + PrefabName);
                GameObject g = Object.Instantiate(prefab, new Vector3((float)PosX, (float)PosY, (float)PosZ), new Quaternion((float)RotX, (float)RotY, (float)RotZ, (float)RotW)) as GameObject;
                return g;
            }
        }

        /// <summary>
        /// ステージ中の固定アイテム用クラス
        /// </summary>
        public class Item
        {
            public double PosX;
            public double PosY;
            public double PosZ;

            public double RotX;
            public double RotY;
            public double RotZ;
            public double RotW;

            public string PrefabName;

            public Item()
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

            public Item(GameObject g)
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
            }

            public GameObject Load()
            {
                GameObject prefab = Resources.Load<GameObject>("/Prefab/Item/" + PrefabName);
                GameObject g = Object.Instantiate(prefab, new Vector3((float)PosX, (float)PosY, (float)PosZ), new Quaternion((float)RotX, (float)RotY, (float)RotZ, (float)RotW)) as GameObject;
                return g;
            }
        }

        #endregion

        public static void Save(string stagename)
        {
            Stage stage = new Stage();
            stage.Terrains = new List<Terrain>();
            stage.Gimmicks = new List<Gimmick>();
            stage.Flags = new List<Flag>();
            stage.Items = new List<Item>();


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

            Transform parent;

            parent = (GameObject.Find("/Terrains") as GameObject).transform;
            foreach(var item in json["Terrains"])
            {
                GameObject g = item.Get<Terrain>().Load();
                g.transform.SetParent(parent);
            }

            parent = (GameObject.Find("/Gimmicks") as GameObject).transform;
            foreach (var item in json["Gimmicks"])
            {
                GameObject g = item.Get<Terrain>().Load();
                g.transform.SetParent(parent);
            }

            parent = (GameObject.Find("/Flags") as GameObject).transform;
            foreach (var item in json["Flags"])
            {
                GameObject g = item.Get<Terrain>().Load();
                g.transform.SetParent(parent);
            }

            parent = (GameObject.Find("/Items") as GameObject).transform;
            foreach (var item in json["Items"])
            {
                GameObject g = item.Get<Terrain>().Load();
                g.transform.SetParent(parent);
            }
        }
    }
}
