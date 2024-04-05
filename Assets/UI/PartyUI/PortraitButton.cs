using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class PortraitButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    [SerializeField] private UnityEngine.UI.Image portraitImage;
    [SerializeField] private UnityEngine.UI.Image coverImage;
    [SerializeField] private TMP_Text studentName;
    [SerializeField] private List<GameObject> skillInfo;
    public int Idx;
    private GameObject info;
    public void InitPortrait(StudentList.StudentInfo studentInfo, int idx)
    {
        portraitImage.sprite = studentInfo.Portrait;
        coverImage.sprite = studentInfo.BackgroundImage;
        studentName.text = studentInfo.Name;
        Idx = idx;
        info = Instantiate(skillInfo[studentInfo.SkillType], transform);
        var amplierSettingObject = info.GetComponent<AmplierSetting>();
        amplierSettingObject.SetText(studentInfo.Amplier);
        info.transform.localPosition = new Vector2(-200f, 100f);
        info.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        info.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        info.SetActive(false);
    }
}
