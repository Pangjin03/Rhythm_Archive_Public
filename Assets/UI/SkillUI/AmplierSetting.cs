using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AmplierSetting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text amplierText;
    public void SetText(int amplier)
    {
        amplierText.text = amplier.ToString();
    }
}
