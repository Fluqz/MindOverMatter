using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    public Image content;

    public void ReduceHealthbar(float currentHealth, float MaxHealth, float minHealth) {
        content.fillAmount = ((currentHealth - minHealth) * (1 - 0) / (MaxHealth - minHealth) + 0);
    }
}
