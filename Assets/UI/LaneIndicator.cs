using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneIndicator : MonoBehaviour
{
    [SerializeField] private GameObject redLane;
    [SerializeField] private GameObject yellowLane;
    [SerializeField] private GameObject blueLane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            redLane.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            redLane.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            yellowLane.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            yellowLane.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            blueLane.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            blueLane.SetActive(false);
        }
    }
}
