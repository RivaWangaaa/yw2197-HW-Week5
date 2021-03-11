using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float forceAmount = 5;  //public var for force amount
    
    Rigidbody2D rb2D; //var for the Rigidbody2D

    //static variable means the value is the same for all the objects of this class type and the class itself
    public static PlayerControl instance; //this static var will hold the Singleton

    public GameObject black1;
    public GameObject red1;
    public GameObject orange1;
    public GameObject yellow1;
    public GameObject blue1;
    public GameObject green1;
    public GameObject purple1;
    public GameObject pink1;
    public GameObject navy1;
    public GameObject brown1;

    private GameObject obj = null;

    private Vector2 colorPositon = new Vector2(2, 2);

    private int random = 0;
    void Awake()
    {
        if (instance == null)  //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this; //set instance to this object
        }
        else //if the instance is already set to an object
        {
            Destroy(gameObject);  //destroy this new object, so there is only ever one
        }
    }

    void ChangeColor()
    {
        switch (random)
        {
            case '0':
                obj = Instantiate<GameObject>(black1);
                break;
            case '1':
                obj = Instantiate<GameObject>(red1);
                break;
            case '2':
                obj = Instantiate<GameObject>(orange1);
                break;
            case '3':
                obj = Instantiate<GameObject>(yellow1);
                break;
            case '4':
                obj = Instantiate<GameObject>(blue1);
                break;
            case '5':
                obj = Instantiate<GameObject>(green1);
                break;
            case '6':
                obj = Instantiate<GameObject>(purple1);
                break;
            case '7':
                obj = Instantiate<GameObject>(pink1);
                break;
            case '8':
                obj = Instantiate<GameObject>(navy1);
                break;
            case '9':
                obj = Instantiate<GameObject>(brown1);
                break;
            default:
                obj = null;
                break;
        }

      
        
            obj.transform.position = colorPositon;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //get the Rigidbody2D  off of this gameObject
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W)) //if W is pressed
        {
            rb2D.AddForce(Vector2.up * forceAmount); //apply to the up mult by the "force" var
            random = Random.Range(0, 9);
            print(random);
            ChangeColor();
        }

        if (Input.GetKey(KeyCode.S)) //if S is pressed
        {
            rb2D.AddForce(Vector2.down * forceAmount); //apply to the up mult by the "force" var
        }

        if (Input.GetKey(KeyCode.A)) //if A is pressed
        {
            rb2D.AddForce(Vector2.left * forceAmount); //apply to the up mult by the "force" var
        }

        if (Input.GetKey(KeyCode.D)) //if D is pressed
        {
            rb2D.AddForce(Vector2.right * forceAmount); //apply to the up mult by the "force" var
        }
        
        
    }
}
