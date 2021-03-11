using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ASCIILoader : MonoBehaviour
{
//offset vars for the level position
    public float xOffset;
    public float yOffset;
    
    //Prefabs for the gameObjects we want to add to our scene
    public GameObject player;
    public GameObject wall;
    public GameObject obstacle;
    public GameObject black;
    public GameObject red;
    public GameObject orange;
    public GameObject yellow;
    public GameObject blue;
    public GameObject green;
    public GameObject purple;
    public GameObject pink;
    public GameObject navy;
    public GameObject brown;
    
    
    
    //name of the level file
    public string fileName = "level.txt";
    

    //empty game object that holds the level
    public GameObject level;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(); //call load level
    }

    //function that creates the level based on the ASCII Text File
    void LoadLevel()
    {
        //build up a new level path based on the currentLevel
        string current_file_path = //build path to the level file
            Application.dataPath + 
            "/Levels/" + 
            fileName;

        //pull the contents of the file into a string array
        //each line in the file becomes an item in the array
        string[] fileLines = File.ReadAllLines(current_file_path);
        
        //loop through each line
        for (int y = 0; y < fileLines.Length; y++)
        {
            //get the current line
            string lineText = fileLines[y];

            //split the line into a char array
            char[] characters = lineText.ToCharArray();

            //loop through each char
            for (int x = 0; x < characters.Length; x++)
            {
                //grab the current char
                char c = characters[x];

                //var for newObj
                GameObject newObj;

                switch (c) //switch statement for the car
                {
                    case 'p': //if char is a 'p'
                        //make a player gameObject
                        newObj = Instantiate<GameObject>(player);
                        break;
                    case 'w': //if char is a 'w'
                        //make a wall
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    case '<':
                        newObj = Instantiate<GameObject>(obstacle);
                        break;
                    case '!':
                        newObj = Instantiate<GameObject>(black);
                        break;
                    case '@':
                        newObj = Instantiate<GameObject>(red);
                        break;
                    case '#':
                        newObj = Instantiate<GameObject>(orange);
                        break;
                    case '$':
                        newObj = Instantiate<GameObject>(yellow);
                        break;
                    case '%':
                        newObj = Instantiate<GameObject>(blue);
                        break;
                    case '^':
                        newObj = Instantiate<GameObject>(green);
                        break;
                    case '&':
                        newObj = Instantiate<GameObject>(purple);
                        break;
                    case '*':
                        newObj = Instantiate<GameObject>(pink);
                        break;
                    case '(':
                        newObj = Instantiate<GameObject>(navy);
                        break;
                    case ')':
                        newObj = Instantiate<GameObject>(brown);
                        break;
                    
                    default: //if the char is anything else
                        newObj = null;  //make newObj null
                        break;
                }
                if (newObj != null) //if newObj is not null
                {
                   
                    //whatever newObj is, set it's position based on the offsets
                    //and it's position in the file
                    newObj.transform.position = 
                        new Vector3(x + xOffset, -y + yOffset, 0);
                }

              
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
