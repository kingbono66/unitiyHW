using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Image hpGuage;
    // Start is called before the first frame update
    void Start()
    {
        hpGuage = GameObject.Find("Hp_gauge").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHP()
    {
        hpGuage.fillAmount -= 0.25f;
    }
}
