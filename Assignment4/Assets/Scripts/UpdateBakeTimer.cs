using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateBakeTimer : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Gameplay.ThisGameplay.BakeTimer > 0)
        {
            text.text = "Bake Timer: " + Gameplay.ThisGameplay.BakeTimer;
        }
        else
        {
            text.text = "";
        }
    }
}
