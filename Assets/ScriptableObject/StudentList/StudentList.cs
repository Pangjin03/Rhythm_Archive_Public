using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "StudentList", menuName = "Scriptable Object/Student List")]
public class StudentList : ScriptableObject
{
    [System.Serializable]
    public class StudentInfo
    {
        [SerializeField] private string name;
        public string Name => name;
        [SerializeField] private string skillName;
        public string SkillName => skillName;
        [SerializeField] private Sprite backgroundImage;
        public Sprite BackgroundImage=> backgroundImage;
        [SerializeField] private Sprite portrait;
        public Sprite Portrait=> portrait;
        [SerializeField] private int skillType;
        public int SkillType => skillType;
        [SerializeField] private int amplier;
        public int Amplier => amplier;
        [SerializeField] private int cost;
        public int Cost => cost;
    }
    public List<StudentInfo> studentInfo;
}