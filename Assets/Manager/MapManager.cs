using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public float startPos;
    private float blockdist;
    [SerializeField] public float scrollSpeed;
    [SerializeField] public float bpm;
    [SerializeField] public BeatMap beatMap;
    [SerializeField] private BlockList blockList;
    public AudioSource audioSource;
    // Start is called before the first frame update
    public void Awake()
    {
        gameObject.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        blockdist = 4f;
    }
    public void Update()
    {

    }
    public void InitMap()
    {
        int i = 0;
        scrollSpeed = bpm * blockdist / 3600f;
        startPos = -6f + scrollSpeed * 300f;
        foreach (var beatInfo in beatMap.beatMap)
        {
            int red = beatInfo.Red;
            int yellow = beatInfo.Yellow;
            int blue = beatInfo.Blue;
            if (red > 0)
            {
            GameObject RedNoteObject = Instantiate(blockList.blocklist[red - 1].Block, transform);
            RedNoteObject.transform.position = new Vector2(-2.1f, (startPos + blockdist * i));
            RedNoteObject.transform.localScale = new Vector3(2f, blockdist, 1f);
            var RedMove = RedNoteObject.GetComponent<Move>();
            RedMove.speed = scrollSpeed;
            RedMove.keycode = KeyCode.Z;
            RedMove.color = "Red";
            RedMove.second = "Yellow";
            }
            if (yellow > 0)
            {
            GameObject YellowNoteObject = Instantiate(blockList.blocklist[yellow - 1].Block, transform);
            YellowNoteObject.transform.position = new Vector2(0f, (startPos + blockdist * i));
            YellowNoteObject.transform.localScale = new Vector3(2f, blockdist, 1f);
            var YellowMove = YellowNoteObject.GetComponent<Move>();
            YellowMove.speed = scrollSpeed;
            YellowMove.keycode = KeyCode.X;
            YellowMove.color = "Yellow";
            YellowMove.second = "Blue";
            }
            if (blue > 0)
            {
            GameObject BlueNoteObject = Instantiate(blockList.blocklist[blue - 1].Block, transform);
            BlueNoteObject.transform.position = new Vector2(2.1f, (startPos + blockdist * i));
            BlueNoteObject.transform.localScale = new Vector3(2f, blockdist, 1f);
            var BlueMove = BlueNoteObject.GetComponent<Move>();
            BlueMove.speed = scrollSpeed;
            BlueMove.keycode = KeyCode.C;
            BlueMove.color = "Blue";
            BlueMove.second = "Red";
            }
            i = i + 1;
        }
        Debug.Log(audioSource.gameObject.activeSelf);
    }
    
}
