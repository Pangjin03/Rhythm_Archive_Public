using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeatMapCoverImage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public MapList mapList;
    [SerializeField] private AudioSource audioSource;
    private UnityEngine.UI.Image image;
    void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetImage(int Idx)
    {
        audioSource.Stop();
        image.sprite = mapList.beatmapInfo[Idx].CoverImage;
        audioSource.clip = mapList.beatmapInfo[Idx].audioClip;
        audioSource.Play();
    }
    public void OffMusic()
    {
        audioSource.Stop();
    }
}
