using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject StartPos;
    [SerializeField] private GameObject DestPos;
    [SerializeField] private UnityEngine.UI.Image skillPortrait;
    [SerializeField] private TMP_Text skillText;
    private GameObject targetPos;
    private float speed;
    Vector3 vel = Vector3.zero;
    void Start()
    {
        transform.position = StartPos.transform.position;
        targetPos = StartPos;
        speed = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPos.transform.position, ref vel, Time.deltaTime * speed);
    }

    public void SkillAnimation(Sprite portrait, string skillName)
    {
        StopCoroutine("EndAnimation");
        speed = 40f;
        transform.position = StartPos.transform.position;
        skillPortrait.sprite = portrait;
        skillText.text = skillName;
        targetPos = DestPos;
        StartCoroutine("EndAnimation");
    }

    IEnumerator EndAnimation()
    {
        yield return new WaitForSeconds(2.5f);
        speed = 20f;
        targetPos = StartPos;
    }
}
