using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("AbilityCollection")]
public class AbilityContainer {
    [XmlArray("Abilities")]
    [XmlArrayItem("Ability")]
    public List<AbilityA> abilities = new List<AbilityA>();

    public static AbilityContainer Load(string path) {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(AbilityContainer));

        Stream reader = new FileStream(path, FileMode.Open);

        AbilityContainer abilities = serializer.Deserialize(reader) as AbilityContainer;
        reader.Close();

        return abilities;
    }
}
