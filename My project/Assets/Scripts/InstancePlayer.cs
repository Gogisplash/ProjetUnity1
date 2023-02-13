using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePlayer : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public GameObject PlayerInstance;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInstance = Instantiate(PlayerPrefab);
        PlayerInstance.GetComponent<SliderUse>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
