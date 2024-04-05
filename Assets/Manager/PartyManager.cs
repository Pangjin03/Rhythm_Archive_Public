using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PartyManager : MonoBehaviour
{
    [SerializeField] private GameObject redPortrait;
    [SerializeField] private GameObject yellowPortrait;
    [SerializeField] private GameObject bluePortrait;
    [SerializeField] private UnityEngine.UI.Image redIngame;
    [SerializeField] private UnityEngine.UI.Image yellowIngame;
    [SerializeField] private UnityEngine.UI.Image blueIngame;
    [SerializeField] private UnityEngine.UI.Image redPartyImage;
    [SerializeField] private UnityEngine.UI.Image yellowPartyImage;
    [SerializeField] private UnityEngine.UI.Image bluePartyImage;
    [SerializeField] private StudentList redStudentList;
    [SerializeField] private StudentList yellowStudentList;
    [SerializeField] private StudentList blueStudentList;
    [SerializeField] public List<StudentList.StudentInfo> studentList;

    public void OnClickPortrait()
    {
        Debug.Log("click");
        var portraitObject = EventSystem.current.currentSelectedGameObject.GetComponent<PortraitButton>();
        if (redPortrait.activeSelf)
        {
        studentList[0] = redStudentList.studentInfo[portraitObject.Idx];
        }
        if (yellowPortrait.activeSelf)
        {
        studentList[1] = yellowStudentList.studentInfo[portraitObject.Idx];
        }
        if (bluePortrait.activeSelf)
        {
        studentList[2] = blueStudentList.studentInfo[portraitObject.Idx];
        }
        SetPartyImage();
    }
    private void SetPartyImage()
    {
        redPartyImage.sprite = studentList[0].Portrait;
        yellowPartyImage.sprite = studentList[1].Portrait;
        bluePartyImage.sprite = studentList[2].Portrait;
    }
    public void InitIngame()
    {
        redIngame.sprite = studentList[0].Portrait;
        yellowIngame.sprite = studentList[1].Portrait;
        blueIngame.sprite = studentList[2].Portrait;
    }
    public StudentList.StudentInfo GetStudentInfo(int idx)
    {
        return studentList[idx];
    }
}
