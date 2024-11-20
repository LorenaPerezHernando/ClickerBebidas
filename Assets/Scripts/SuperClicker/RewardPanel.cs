using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


public class RewardPanel : MonoBehaviour
{
    private int clickCount;

    [Header("---Text Logros ---")]
    [SerializeField] private TextMeshProUGUI t_100Clicks;
    [SerializeField] private TextMeshProUGUI t_1000Clicks;
    [SerializeField] private TextMeshProUGUI t_10kClicks;
    [SerializeField] private TextMeshProUGUI t_100kClicks;

    [Header("---Objects ---")]
    [SerializeField] List<GameObject> firstRow;
    [SerializeField] List<GameObject> secondRow;
    [SerializeField] List<GameObject> thirdRow;
    [SerializeField] TextMeshProUGUI t_firstRow;
    [SerializeField] TextMeshProUGUI t_secondRow;
    [SerializeField] TextMeshProUGUI t_thirdRow;
    [SerializeField] int rowsFinished;

    [Header("---Time ---")]
    float time;
    [SerializeField] TextMeshProUGUI t_onehour;
    [SerializeField] TextMeshProUGUI t_twohour;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //ClickCount
        {
            clickCount++;
        
            if (clickCount == 100)
                t_100Clicks.color = Color.black;
            if (clickCount == 1000)
                t_1000Clicks.color = Color.black;
            if (clickCount == 10000)
                t_10kClicks.color = Color.black;
            if (clickCount == 100000)
                t_100kClicks.color = Color.black;
        }
        
        //Rows Count
        if (firstRow.All(obj => !obj.activeSelf)) 
            rowsFinished++;
        if (secondRow.All(obj => !obj.activeSelf)) 
            rowsFinished++;
        if (thirdRow.All(obj => !obj.activeSelf)) 
            rowsFinished++;

        if (rowsFinished == 1)
            t_firstRow.color = Color.black;
        if (rowsFinished == 2)
            t_secondRow.color = Color.black;
        if (rowsFinished == 3)
            t_thirdRow.color = Color.black;


        time += Time.deltaTime;

        if (time > 3600)
            t_onehour.color = Color.black;



    }
}
