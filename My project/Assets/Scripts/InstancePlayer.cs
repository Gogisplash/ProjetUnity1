using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePlayer : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public SliderUse FoodBarPrefab;
    public SliderUse HealthBarPrefab;
    public SliderUse StaminaBarPrefab;
    public Canvas CanvaStatPrefab;

    public GameObject PlayerInstance;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInstance = Instantiate(PlayerPrefab);
/*        FoodBarPrefab = Instantiate(FoodBarPrefab);
        HealthBarPrefab = Instantiate(HealthBarPrefab);
        StaminaBarPrefab = Instantiate(StaminaBarPrefab);*/
        CanvaStatPrefab= Instantiate(CanvaStatPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
