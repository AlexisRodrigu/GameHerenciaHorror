using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private bool gameOver = false;
    [SerializeReference] private GameObject player;
    //[SerializeField] private GameObject gun;

    public GameObject Player { get { return player; } }
    //public GameObject Gun { get { return gun; } }
    public bool GameOver { get { return gameOver; } }
    public GameObject completeLevelUI;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void PlayerHit (int punch)
    {
        if(punch > 0)
        {
            gameOver = false;
        }
        else
        {
            gameOver = true;
        }
    }
    public void FinalLevel()
    {
        completeLevelUI.SetActive(true);
    }
}
