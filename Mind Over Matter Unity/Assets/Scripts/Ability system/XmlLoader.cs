using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class XmlLoader : MonoBehaviour {

    public const string path = "Assets/Scripts/Ability system/abilities.xml";

    XmlDocument doc = new XmlDocument();
    
    void Awake() {
        doc.Load(path);

        XmlNode baseNode = doc.DocumentElement;

        foreach(XmlNode node in baseNode.ChildNodes) {
            
        }
    }

}
