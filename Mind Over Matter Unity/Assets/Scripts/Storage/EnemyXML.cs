using System.Collections;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class EnemyXML {

    [XmlAttribute("name")]
    public string name;

    [XmlElement("Description")]
    public string description;
    
    [XmlElement("Health")]
    public int health;

    [XmlElement("Weight")]
    public int weight;

    [XmlElement("AttackDamage")]
    public int attackDamage;

    [XmlElement("AttackRadius")]
    public float attackRadius;

    [XmlElement("TerretoryRadius")]
    public float terretoryRadius;

    [XmlElement("MovementSpeed")]
    public string movementSpeed;
}
