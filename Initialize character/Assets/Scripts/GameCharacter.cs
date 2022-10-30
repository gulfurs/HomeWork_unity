using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{
    public string charName = "hans";
    private int level = 4;
    public int levelup = 1;
    // Start is called before the first frame update
    void Start()
    {
           charLevel("hans", 4, 1);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void charLevel(string cName, int level, int levelup){
        level = level + levelup;
        Debug.Log(cName + " is on level " + level);
        
    }

}
