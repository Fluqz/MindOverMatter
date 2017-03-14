using UnityEngine;
using System.Collections;

public class Item {

    private string name,
                    description;

    private ItemType itemType;

    public enum ItemType {
        HEALTHPOTION,
        SHIT,
        RAPIDFIRE
    }
    
    public Item(string name, string description, ItemType itemType) {
        itemType = ItemType.HEALTHPOTION;

        this.name = name;
        this.description = description;
    }

    public string Name { get; set; }
    public string Description { get; set; }
}
