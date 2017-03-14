using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

[XmlRoot("EnemyContainer")]
public class EnemyXMLContainer {

    [XmlArray("Enemies")]
    [XmlArrayItem("Enemy")]
    public List<EnemyXML> enemies = new List<EnemyXML>();

    public static EnemyXMLContainer LoadEnemyInformation(string path) {

        TextAsset xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(EnemyXMLContainer));

        StringReader reader = new StringReader(xml.text);

        EnemyXMLContainer enemies = serializer.Deserialize(reader) as EnemyXMLContainer;

        reader.Close();

        return enemies;
    }

}
