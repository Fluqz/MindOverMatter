using UnityEngine;
using System.Collections;

public class BaseEquipment : BaseStatItem {
    
    public enum EquipmentTypes {
        HEAD,
        NECK,
        SHOULDERS,
        CHEST,
        LEGS,
        FEET
    }
    private EquipmentTypes equimentType;
    private int spellEffectID;

    public EquipmentTypes EquipmentType { get; set; }
    public int SpellEffectID { get; set; }
}
