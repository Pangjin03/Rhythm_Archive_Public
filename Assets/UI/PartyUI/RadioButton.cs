using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RadioButton : MonoBehaviour
{
    [SerializeField] private GameObject redPortrait;
    [SerializeField] private GameObject yellowPortrait;
    [SerializeField] private GameObject bluePortrait;
    // Start is called before the first frame update
    public void OnClickRedButton()
    {
        redPortrait.SetActive(true);
        yellowPortrait.SetActive(false);
        bluePortrait.SetActive(false);
    }

    public void OnClickYellowButton()
    {
        redPortrait.SetActive(false);
        yellowPortrait.SetActive(true);
        bluePortrait.SetActive(false);
    }

    public void OnClickBlueButton()
    {
        redPortrait.SetActive(false);
        yellowPortrait.SetActive(false);
        bluePortrait.SetActive(true);
    }
}
