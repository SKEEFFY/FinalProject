using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyDebug : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Update() {
        _text.text = Input.GetKey(KeyCode.Space) ? "Space Pressed = <color=green>True</color>" : "Space Pressed = <color=red>False</color>";
    }
}
