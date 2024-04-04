using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public KeyCode keycode;
    public string color;
    public string second;
    private int stack;
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        stack = 0;
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keycode) && transform.position.y < (-6f + 0.5f * transform.localScale.y) && transform.position.y > (-6f - 0.5f * transform.localScale.y))
        {
            if (gameObject.CompareTag(color))
            {
                //disable image
                _gameManager.OnSuccess(color);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag(second))
            {
                if (stack == 0)
                {
                    stack += 1;
                    transform.Translate(new Vector2(0f, transform.localScale.y / 4));
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, 1f);
                }
                else
                {
                    _gameManager.OnSuccess(second);
                    Destroy(gameObject);
                }
            }
            else
            {
                _gameManager.OnMiss();
                Destroy(gameObject);
            }
        }
        transform.Translate(new Vector2(0f, -120f * speed * Time.deltaTime));

        if (transform.position.y < -10f && (gameObject.CompareTag(color) || gameObject.CompareTag(second)))
        {
            _gameManager.OnMiss();
            Destroy(gameObject);
        }
    }
}
