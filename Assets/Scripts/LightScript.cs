using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public float currentValue;
    public float decrementor;
    public float incrementor;
    public float threshHold;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        currentValue = 12;
        transform.localScale = new Vector3(currentValue, currentValue, 0);        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue <= 0) return;
        timer += Time.deltaTime;
        if(timer > threshHold)
        {
            DecrementScale();
            timer = 0;
        }

    }

    public void IncrementScale()
    {
        currentValue += incrementor;
        if (currentValue >= 15) {
            decrementor = 4;
            threshHold = 2;
        }else if(currentValue >= 18)
        {
            decrementor = 5;
            threshHold = 1; 
        }
        else
        {
            decrementor = 3;
            threshHold = 3;
        }
        transform.localScale = new Vector3(currentValue, currentValue, 0);
    }

    void DecrementScale()
    {
        currentValue -= decrementor;
        if (currentValue <= 0)
        {
            currentValue = 0;
            ExiterScript.EndGame();
        }
        transform.localScale = new Vector3(currentValue, currentValue, 0);
    }
}
