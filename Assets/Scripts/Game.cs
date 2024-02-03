using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;
    public int lives = 3;
    public static int score = 0;
    public Spawner jetmanSpawner;
    public GameObject jetman;
    public Renderer jetmanRenderer;
    
    int goods = 0;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Singleton violation");
            return;
        }
        instance = this;
    }

    void Start()
    {
        CreateJetpack();
    }

    void CreateJetpack()
    {
        if (jetman != null)
        {
            Destroy(jetman);
        }
        jetman = jetmanSpawner.Spawn();
        Color randomColor = new Color(Random.Range(0,255), Random.Range(0,255), Random.Range(0,255));
        jetmanRenderer.sharedMaterial.color = randomColor;
    }

    public void RegisterGood()
    {
        goods++;
    }

    public void UnregisterGood()
    {
        goods--;
        score += 50;
        Debug.Log("Score: " + score);
        if (goods == 0)
        {
            Debug.Log("You Win!!!!!");
        }
        else
        {
            Debug.Log(goods + " Remaining");

        }
    }

    public void Die()
    {
        lives--;
        score -= 100;
        Debug.Log("Score: " + score);
        if (lives > 0)
        {
            CreateJetpack();
        }
        else
        {
            Debug.Log("You Lose!");

        }
    }
}

