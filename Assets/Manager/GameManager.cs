using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager mapManager;
    [SerializeField] private UIMapManager UImapManager;
    [SerializeField] private PartyManager partyManager;
    [SerializeField] private SkillManager skillManager;
    [SerializeField] private MapList mapList;
    [SerializeField] public GameObject beatMapUI;
    [SerializeField] public GameObject indicator;
    [SerializeField] public GameObject startUI;
    [SerializeField] private GameObject stopUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject partySettingUI;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ScrollBarController scrollBarController;
    [SerializeField] private BeatMapCoverImage beatMapCoverImage;
    [SerializeField] private TMP_Text beatMapNameText;
    [SerializeField] private TMP_Text comboText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private AudioSource mainAudio;
    [SerializeField] private List<Slider> manaList;
    [SerializeField] private Slider hpBar;
    [SerializeField] private AudioClip lobbyMusic;
    [SerializeField] private AudioClip partySettingMusic;
    private int idx;
    private int combo;
    private int score;
    private int _shield = 0;
    private int _double = 0;
    private bool IsPlaying;
    // Start is called before the first frame update
    void Awake()
    {
        MainUIActive(true);
        stopUI.SetActive(false);
        Debug.Log(beatMapUI.activeSelf);
        mainAudio.clip = lobbyMusic;
        mainAudio.Play();
        beatMapUI.SetActive(false);
        gameUI.SetActive(false);
        partySettingUI.SetActive(false);
        IsPlaying = false;
    }
    public void StartMap(int idx)
    {
        beatMapCoverImage.OffMusic();
        scrollBarController.OffMusic();
        var mapManagerObject = mapManager.GetComponent<MapManager>();
        var targetMap = mapList.beatmapInfo[idx];
        beatMapNameText.text = targetMap.Name;
        mapManagerObject.bpm = targetMap.Bpm;
        //mapManagerObject.scrollSpeed = 11.2f / targetMap.Bpm;
        mapManagerObject.beatMap = targetMap.beatMap;
        var audioSourceObject = mapManager.GetComponent<AudioSource>();
        audioSourceObject.clip = targetMap.audioClip;
        mapManager.InitMap();
        partyManager.InitIngame();
        PartyUIInit();
        Invoke("PlayMusics", 2.5f - (30f/targetMap.Bpm));
        beatMapUIActive(false);
        SetCombo(0);
        SetScore(0);
        hpBar.value = 100f;
        gameUI.SetActive(true);
    }

    public void StopUI()
    {
        stopUI.SetActive(true);
        Time.timeScale = 0;
        audioSource.Pause();
    }
    public void ResumeUI()
    {
        stopUI.SetActive(false);
        Time.timeScale = 1;
        audioSource.UnPause();
    }
    public void PartyUIInit()
    {
        for (int _index = 0; _index < 3; _index++)
        {
            var partyInfo = partyManager.GetStudentInfo(_index);
            manaList[_index].maxValue = partyInfo.Cost;
            Debug.Log(partyInfo.Cost);
            Debug.Log(partyInfo.Name);
        }
    }
    public void OnMiss()
    {
        if (_shield > 0)
        {
            _shield -= 1;
        }
        else
        {
            SetCombo(0);
            SetScore(score);
            hpBar.value -= 5f;
            if (hpBar.value <= 0f)
            {
                OnClickLobbyButton();
                IsPlaying = false;
                //GameOver()
            }
        }
    }
    
    public void OnSuccess(string Color)
    {
        int _colorCode;
        int blockscore = 500;
        if (_double > 0)
        {
            _double -= 1;
            blockscore = 1000;
        }
        SetCombo(combo + 1);
        SetScore(score + blockscore);
        switch (Color)
        {
            case "Red":
                _colorCode = 0;
                break;
            case "Yellow":
                _colorCode = 1;
                break;
            case "Blue":
                _colorCode = 2;
                break;
            default:
                _colorCode = 0;
                break;  
        }
        manaList[_colorCode].value = manaList[_colorCode].value + 0.1f;
        if (manaList[_colorCode].value >= manaList[_colorCode].maxValue)
        {
            OnSkill(_colorCode);
            manaList[_colorCode].value = 0;
        }
    }

    public void OnSkill(int colorCode)
    {
        var skillInfo = partyManager.GetStudentInfo(colorCode);
        switch (skillInfo.SkillType)
        {
            case 0:
                _double += skillInfo.Amplier;
                break;
            case 1:
                SetScore(score + skillInfo.Amplier);
                break;
            case 2:
                hpBar.value = Mathf.Min(100f, hpBar.value + skillInfo.Amplier);
                break;
            case 3:
                _shield += skillInfo.Amplier;
                break;
            default:
                break;
        }
        skillManager.SkillAnimation(skillInfo.Portrait, skillInfo.SkillName);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && beatMapUI.activeSelf)
        {
            idx = scrollBarController.GetMapIdx();
            StartMap(idx);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (beatMapUI.activeSelf)
            {
                OnClickMainButton();
            }
            else if (!startUI.activeSelf)
            {
                StopUI();
            }
        }
        if (!audioSource.isPlaying && !stopUI.activeSelf && IsPlaying)
        {
            Invoke("ResultUIActive", 3f);    
        }
    }
    public void ResultUIActive()
    {
        //resultUI.SetActive();
        OnClickLobbyButton();
        IsPlaying = false;
    }
    public void OnClickResumeButton()
    {
        ResumeUI();
    }

    public void OnClickLobbyButton()
    {
        var mapManagerObject = mapManager.GetComponent<MapManager>();
        Transform[] childList = mapManagerObject.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                {
                    Destroy(childList[i].gameObject);
                }
            }
        }
        ResumeUI();
        audioSource.Stop();
        CancelInvoke();
        beatMapUIActive(true);
        scrollBarController.PlayMusic();
        audioSource.Stop();
        gameUI.SetActive(false);
        IsPlaying = false;
    }
    public void OnClickPartyButton()
    {
        partySettingUI.SetActive(true);
        mainAudio.Stop();
        mainAudio.clip = partySettingMusic;
        mainAudio.Play();
        MainUIActive(false);
        var radioButton = FindObjectOfType<RadioButton>();
        radioButton.OnClickRedButton();
    }
    public void PlayMusics()
    {
        Debug.Log("Play");
        audioSource.Play();
        IsPlaying = true;
    }
    public void beatMapUIActive(bool value)
    {
        beatMapUI.SetActive(value);
        indicator.SetActive(value);
    }
    public void MainUIActive(bool value)
    {
        startUI.SetActive(value);
        startButton.SetActive(value);
        settingButton.SetActive(value);
    }
    public void OnClickMainButton()
    {
        beatMapCoverImage.OffMusic();
        scrollBarController.OffMusic();
        mainAudio.Stop();
        beatMapUIActive(false);
        MainUIActive(true);
        CancelInvoke();
        partySettingUI.SetActive(false);
        mainAudio.clip = lobbyMusic;
        mainAudio.Play();
    }
    public void OnClickStartButton()
    {
        MainUIActive(false);
        mainAudio.Stop();
        beatMapUIActive(true);
        UImapManager.InitBeatMapList();
        if (beatMapCoverImage.mapList != null)
        {
            scrollBarController.PlayMusic();
        }
    }
    private void SetScore(int NewScore)
    {
        score = NewScore;
        scoreText.text = score.ToString();
    }
    private void SetCombo(int NewCombo)
    {
        combo = NewCombo;
        comboText.text = combo.ToString();
    }
}
