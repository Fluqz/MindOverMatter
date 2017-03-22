using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PlayerInformation {
    private static string name,
                            description;
    private static int maxHealth, 
                        currentHealth;
    private static float movementSpeed;

    private static Vector3 position;
    private static Vector2 spawnPosition;
    private static Vector2 direction;

    private static Ability[] abilities;

    private static GameObject playerGO;

    private static List<Item> items = new List<Item>();
    
    public static void TakeDamage(int damage) {
        currentHealth -= damage;
    }

    public static void GetHeal(int heal) {
        currentHealth += heal;
    }

    public static void AddItem(Item item) {
        items.Add(item);
    }

    public static void RemoveItem(Item item) {
        items.Remove(item);
    }

    public static string Name { get; set; }
    public static string Description { get; set; }
    public static int MaxHealth { get; set; }
    public static int CurrentHealth { get; set; }
    public static float MovementSpeed { get; set; }
    public static Vector3 SpawnPosition { get { return spawnPosition; } }
    public static Vector3 Position { get { return position; } set { position = value; spawnPosition = new Vector2(position.x, position.y + .4f); } }
    public static Vector2 Direction { get; set; }
    public static Ability[] Abilities { get; set; }
    public static GameObject PlayerGO { get; set; }
    public static List<Item> Items { get { return items; } }
}
