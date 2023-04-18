using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Start is called before the first frame update

    private Button button;
    private GameManager gameManagerScript;
    public float difficulty;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was Clicked");
        gameManagerScript.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
