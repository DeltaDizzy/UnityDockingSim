using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarper : MonoBehaviour
{
    // Start is called before the first frame update
    private int[] warpFactors = new int[] { 1, 5, 10, 20, 50, 100 };
    public int currentWarp;
    public int selectedFactorIndex = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Period))
        {
            if (selectedFactorIndex >= 0 && selectedFactorIndex < 5)
            {
                selectedFactorIndex += 1;
            }
                
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            if (selectedFactorIndex > 0  && selectedFactorIndex <= 5)
            {
                selectedFactorIndex -= 1;
            }
            
        }
        currentWarp = warpFactors[selectedFactorIndex];
        Time.timeScale = currentWarp; 
        //Debug.Log(selectedFactorIndex);
    }
}
