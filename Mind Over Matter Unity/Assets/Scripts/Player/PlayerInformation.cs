using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PlayerInformation {
    private static string name,
                            description;
    private static int maxHealth, 
                        currentHealth;
    private static float movementSpeed;

    private static Vector2 direction;

    private static Ability[] abilities;

    private static GameObject playerGO;
    
    public static void TakeDamage(int damage) {
        currentHealth -= damage;
    }

    public static void GetHeal(int heal) {
        currentHealth += heal;
    }

    public static string Name { get; set; }
    public static string Description { get; set; }
    public static int MaxHealth { get; set; }
    public static int CurrentHealth { get; set; }
    public static float MovementSpeed { get; set; }
    public static Vector2 Direction { get; set; }
    public static Ability[] Abilities { get; set; }
    public static GameObject PlayerGO { get; set; }
}
