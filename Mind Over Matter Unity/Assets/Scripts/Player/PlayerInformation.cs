﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PlayerInformation {
    private static string name,
                    description;
    private static int currentHealth;
    private static float distance,
                    time;

    private static Ability[] abilities;

    private static GameObject playerGO;
    
    public static void TakeDamage(float damage) {

    }

    public static string Name { get; set; }
    public static string Description { get; set; }
    public static int CurrentHealth { get; set; }
    public static float Distance { get; set; }
    public static float Time { get; set; }
    public static Ability[] Abilities { get; set; }
    public static GameObject PlayerGO { get; set; }
}
