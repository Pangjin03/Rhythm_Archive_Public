using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIMapManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private MapList mapList;
    [SerializeField] private GameObject beatMapButtonPrefab;
    private int i = 0;
    public void InitBeatMapList()
    {
        foreach (var beatmapInfo in mapList.beatmapInfo)
        {
            var beatMapButtonObject = Instantiate(beatMapButtonPrefab, transform);
            var beatMapElem = beatMapButtonObject.GetComponent<BeatMapButton>();
            beatMapElem.Init(beatmapInfo.Name, i);
            i+= 1;

        }
    }
}
