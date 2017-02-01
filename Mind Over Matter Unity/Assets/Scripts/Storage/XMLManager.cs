using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


public class XMLManager : MonoBehaviour {

    public static XMLManager instance;

    public ItemDatabase itemDB;

    void Awake() {
        if (instance == null)
            instance = this;
    }

    public void SaveItems() {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/XML/ability.xml", FileMode.Create);
        serializer.Serialize(stream, itemDB);
        stream.Close();
    } 
    
    public void LoadItems() {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/XML/ability.xml", FileMode.Open);
        itemDB = serializer.Deserialize(stream) as ItemDatabase;
        stream.Close();
    }

    public void LoadEnemyInfo() {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/XML/enemy.xml", FileMode.Create);
        serializer.Serialize(stream, itemDB);
        stream.Close();
    }
}

[System.Serializable]
public class EnemyItem {
    public string name,
                    description;
    public int health,
                weight,
                baseDamage,
                degree,
                criticalStrikeChance;
    public float attackRadius,
                    terretoryRadius,
                    movementSpeed;
}

[System.Serializable]
public class ItemDatabase {
    public List<EnemyItem> list = new List<EnemyItem>();
}