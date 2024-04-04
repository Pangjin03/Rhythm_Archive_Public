using UnityEngine;
using UnityEngine.UI;

public class ScrollBarController : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollSpeed = 0.1f;
    private RectTransform contentRect;
    [SerializeField] private RectTransform indicator;
    [SerializeField] private BeatMapCoverImage beatMapCoverImage;
    
    private int pos;
    public int idx = 0;
    void Start()
    {
        contentRect = scrollRect.content;
        contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, -540f);
        pos = 0;
        idx = 0;
    }

    void Update()
    {
        float y_pos = contentRect.anchoredPosition.y;
        float x_pos = contentRect.anchoredPosition.x;
        indicator.anchoredPosition = new Vector2(640, 450 - pos * 180);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pos > 0)
            {
                pos -= 1;
                idx -= 1;
            }
            else if (y_pos > -450f)
            {
                contentRect.anchoredPosition = new Vector2(x_pos, y_pos - 180f);
                idx -= 1;
            }
            else
            {
                contentRect.anchoredPosition = new Vector2(x_pos, 540f);
                pos = 5;
                idx = 11;
            }
            beatMapCoverImage.SetImage(idx);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pos < 5)
            {
                pos += 1;
                idx += 1;
            }
            else if (y_pos < 540f)
            {
                contentRect.anchoredPosition = new Vector2(x_pos, y_pos + 180f);
                idx += 1;
            }
            else
            {
                contentRect.anchoredPosition = new Vector2(x_pos, -540f);
                pos = 0;
                idx = 0;
            }
            beatMapCoverImage.SetImage(idx);
        }
    }
    public void PlayMusic()
    {
        Debug.Log(idx);
        beatMapCoverImage.SetImage(idx);
    }
    public void OffMusic()
    {
        beatMapCoverImage.OffMusic();
    }
    public int GetMapIdx()
    {
        return idx;
    }
}