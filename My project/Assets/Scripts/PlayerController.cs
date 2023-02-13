using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController mController;
    public Animator mAnimator;
    float Speed = 6f;
    float gravity = -9.10f;
    float jumpHeight = 5f;

    public Transform ground_check;
    public float ground_distance = 0.4f;
    public LayerMask ground_mask;

    Vector3 velocity;
    bool isGrounded;

    public SliderUse healthBar;
    public SliderUse staminaBar;
    public SliderUse foodBar;

    public int Health;

    public int stamina;

    public int food;



    float Endurance;
    float Food;

    float TimeToWait;
    float TimeToUseEndurance;
    float TimeToAddEndurance;
    float TimeToUseFood;
    public float EatingDistance = 1.0f;
    GameObject[] FoodsArray;

    

    // Start is called before the first frame update
    void Start()
    {
        Endurance = 100;
        Food = 100;
        TimeToWait = 0;
        TimeToUseEndurance = 0;
        TimeToAddEndurance = 0;
        TimeToUseFood = 0;

        
        
        
        healthBar.SetMaxSlider(100);


        foodBar.SetMaxSlider(100);


        staminaBar.SetMaxSlider(100);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 10f;
            TimeToUseEndurance += Time.deltaTime;
            if (TimeToUseEndurance > 0.5)
            {
                UseEndurance();
            }
            mAnimator.SetBool("running", true);
        }
        else
        {
            Speed = 5f;
            mAnimator.SetBool("running", false);
        }

        mAnimator.SetFloat("forward", verticalAxis);
        mAnimator.SetFloat("strafe", horizontalAxis);


        Vector3 move = transform.right * horizontalAxis + transform.forward * verticalAxis;

        mController.Move(move * Speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //mAnimator.SetBool("jump", true);
        }
        if (isGrounded)
        {
            mAnimator.SetBool("jump", false);
        }
        else
        {
            mAnimator.SetBool("jump", true);
        }

        velocity.y += gravity * Time.deltaTime;

        mController.Move(velocity * Time.deltaTime);
        // Deplacement et saut
        if (Input.GetKey(KeyCode.A)) { Debug.Log("aaaa"); }
    }
    private void FixedUpdate()
    {
        

        

        //UI
        if (Input.GetKeyDown(KeyCode.M))
        {
            Health -= 20;
            food -= 20;
            stamina -= 20;
            healthBar.SetSlider(Health);
            staminaBar.SetSlider(stamina);
            foodBar.SetSlider(food);
        }
        FoodsArray = GameObject.FindGameObjectsWithTag("Food");
        TimeToUseFood += Time.deltaTime;
        if (TimeToUseFood > 5)
        {
            UseFood();
        }
        TimeToAddEndurance += Time.deltaTime;
        if (Endurance < 100 && Endurance > 10 && TimeToAddEndurance > 1)
        {
            AddEndurance();
            TimeToAddEndurance = 0;
        }
        else
        {
            TimeToWait += Time.deltaTime;
            CheckTime();
        }
        foreach (GameObject element in FoodsArray)
        {
            float Distance = Vector3.Distance(mController.transform.position, element.transform.position);
            if (Input.GetKey(KeyCode.E) && Distance <= EatingDistance)
            {
                AddFood(element);
            }
        }
    }
    void CheckTime()
    {
        TimeToWait += Time.deltaTime;
        if (TimeToWait >= 15)
        {
            Endurance += 40;
            TimeToWait = 0;
        }
    }

    void AddFood(GameObject food)
    {
        Debug.Log("You add 20 Food");
        Food += 20;
        Destroy(food);
    }
    void UseFood()
    {
        Debug.Log("You Loose 5 Food");
        Food -= 5;
        TimeToUseFood = 0;
        if (Food <= 0)
            Debug.Log("You dead");
    }
    void AddEndurance()
    {
        Debug.Log("You add 1 Endurance");
        Endurance += 1;
    }
    void UseEndurance()
    {
        Debug.Log("You Loose 10 Endurance");
        Endurance -= 10;
        TimeToUseEndurance = 0;
    }
}
