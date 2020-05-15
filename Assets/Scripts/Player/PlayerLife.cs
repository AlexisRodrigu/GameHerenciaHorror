using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLife : MonoBehaviour
{
    [SerializeField] int initialLife = 100;
    private float timeSinceLastHit = 1.0f;
    [SerializeField] int currentLife;
    [SerializeField] Slider slider;
    private float timer = 0f;
    [SerializeField]private CharacterController player;

    //GameOver
    public GameObject fps;
    public GameObject gameOverScreen;

    public int CurrentLife {
        get { return currentLife; } 
        set {
            if (value < 0)
                currentLife = 0;
            else
                currentLife = value;
        }
    
    }

    private void Awake()
    {
        Assert.IsNotNull(slider);
    }
    void Start()
    {
        currentLife = initialLife;
        player = GetComponent<CharacterController>();
        fps = GameManager.instance.Player;
    }
    void Update()
    {
        slider.value = currentLife;
        timer += Time.deltaTime;
        
        if( currentLife <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
 void OnTriggerEnter(Collider other)
    {
        if( timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if(other.tag == "ArmEnemy")
            {
               Punch();
                timer = 0;
            }
        }
    }
    void Punch()
    {
        if(currentLife >= 0)
        {
            GameManager.instance.PlayerHit(currentLife);
            currentLife -= 10;
            slider.value = currentLife; 
        }
       if(currentLife <= 0)
        {
            GameManager.instance.PlayerHit(currentLife);
            player.enabled = false;
           

        }      
    }
    public void UpHealth()
    {
        if(currentLife <= 75)
        {
            currentLife += 15;
        }else if(currentLife < initialLife)
        {
            //Igualamos a la vida inicial para que no se pase
            currentLife = initialLife;
            
            fps.gameObject.SetActive(false);
        }
        //Lo agregamos al slider
       // slider.value = currentLife;
    }
}
