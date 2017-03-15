using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    public Image content;

    public void ReduceHealthbar(float currentHealth, float MaxHealth) {
        content.fillAmount = ((currentHealth - 0) * (1 - 0) / (MaxHealth - 0) + 0);
    }
}
