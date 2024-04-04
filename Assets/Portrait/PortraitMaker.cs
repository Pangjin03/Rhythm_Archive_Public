using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitMaker : MonoBehaviour
{
    [SerializeField] private StudentList studentList;
    [SerializeField] private GameObject portraitUI;
    void Start()
    {
        int idx = 0;
        foreach (var portraitInfo in studentList.studentInfo)
        {
            GameObject portraitObject = Instantiate(portraitUI, transform);
            var temp = portraitObject.GetComponent<PortraitButton>(); 
            temp.InitPortrait(portraitInfo, idx);
            idx += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
