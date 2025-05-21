using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI orbCounterText;

    private void Update()
    {
        int orbCount = GameObject.FindGameObjectsWithTag("Orb").Length;
        orbCounterText.text = "Orbes restantes:" + orbCount;
    }
}
