using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab, bombPrefab;
    private const float span = 1f;
    private float delta = 0;
    private bool isPlaying = false;
    private float dropSpeedCoef = 1f;
    

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            delta += Time.deltaTime;
            if (delta > span)
            {
                delta = 0;
                GenerateItems();
            }
        }        
    }
    private void GenerateItems()
    {
        GameObject prefab;
        if (Random.Range(0, 5) == 1)
            prefab = bombPrefab;
        else
            prefab = applePrefab;

        GameObject newItem = Instantiate(prefab);
        newItem.GetComponent<ItemController>().SetDropSpeed(dropSpeedCoef);
        int x = Random.Range(-1, 2);
        int z = Random.Range(-1, 2);
        newItem.transform.position = new Vector3(x, 3, z);
        Debug.Log($"좌표({x},3,{z}) 속도 배율은 " + dropSpeedCoef);
    }
    public void SetFinishGame()
    {
        isPlaying = false;
    }
    public void SetCoef(float coefficient)
    {
        dropSpeedCoef = coefficient;
    }
    public void GameStart()
    {
        isPlaying = true;
    }
}
