using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BeatMap", menuName = "Scriptable Object/Beat Map")]
public class BeatMap : ScriptableObject
{
    [System.Serializable]
    public class BeatInfo
    {
        [SerializeField] private int red;
        public int Red => red;
        [SerializeField] private int yellow;
        public int Yellow => yellow;
        [SerializeField] private int blue;
        public int Blue => blue;
    }
    public List<BeatInfo> beatMap;
}