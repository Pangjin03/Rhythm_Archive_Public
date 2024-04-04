using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BlockList", menuName = "Scriptable Object/Block List")]
public class BlockList : ScriptableObject
{
    [System.Serializable]
    public class BlockInfo
    {
    [SerializeField] private GameObject block;
    public GameObject Block => block;
    }

    public List<BlockInfo> blocklist;
}