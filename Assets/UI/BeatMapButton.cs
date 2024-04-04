using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BeatMapButton : MonoBehaviour
{
    [SerializeField] private TMP_Text beatMapNameText;
    [SerializeField] private TMP_FontAsset newFont;
    public int Idx;
    // Start is called before the first frame update
    public void Init(string name, int idx)
    {
        Debug.Log(name);
        beatMapNameText.text = name;
        beatMapNameText.font = newFont;
        Idx = idx;
    }
}
