using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "MapList", menuName = "Scriptable Object/Map List")]
public class MapList : ScriptableObject
{
    [System.Serializable]
    public class BeatMapInfo
    {
        [SerializeField] private string name;
        public string Name => name;
        [SerializeField] private float bpm;
        public float Bpm => bpm;
        [SerializeField] private Sprite coverImage;
        public Sprite CoverImage=> coverImage;
        [SerializeField] private BeatMap beatmap;
        public BeatMap beatMap => beatmap;
        [SerializeField] private AudioClip audioclip;
        public AudioClip audioClip => audioclip;
    }
    public List<BeatMapInfo> beatmapInfo;
}