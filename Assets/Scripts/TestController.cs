using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    private static TestController instance;
    public static TestController Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<TestController>();
            return instance;
        }
    }

    public RectTransform Joystick;
    public RectTransform Handle;

    public GameObject Player;

    public int MoveingSpeed = 4;
    public Vector2 Swipe;
    public Vector2 dir,dir2;
    public float CameraSpeed=0.4f;

    public bool tap;

    // Start is called before the first frame update
    void Start()
    {
        Joystick.gameObject.SetActive(true);
        Handle.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        #region KeyCode
        /*Reset();
        if (Input.GetKey(KeyCode.A))
        {
            Player.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0) * MoveingSpeed;
            dir = new Vector3(Player.transform.position.x-2, Player.transform.position.y, Player.transform.position.z-20) - Camera.main.transform.position;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0) * MoveingSpeed;
            dir = new Vector3(Player.transform.position.x+2, Player.transform.position.y, Player.transform.position.z-20) - Camera.main.transform.position;
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1)* MoveingSpeed;
            dir = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 15) - Camera.main.transform.position;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1)* MoveingSpeed;
            dir = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 25) - Camera.main.transform.position;
            
        }

        CameraPosition();*/

        #endregion

        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2)
        {
            Joystick.gameObject.SetActive(true);
            Handle.gameObject.SetActive(true);
            Joystick.position = Input.mousePosition;

        }
        if (Input.GetMouseButton(0)&& Input.mousePosition.x< Screen.width/2)
        {
            tap = true;
            Handle.position = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            tap = false;
            Handle.localPosition = Vector2.zero;
        }


        
        if (Input.touches.Length > 0)
        {
            /*if (Input.touches[0].phase == TouchPhase.Began && Input.touches[0].position.x < Screen.width / 2)
            {
                Joystick.localPosition = Input.touches[0].position;
            }*/
            if (Input.touches[0].phase == TouchPhase.Began && Input.touches[0].position.x<Screen.width/2)
            {
                tap = true;
                Handle.localPosition = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Handle.localPosition = Vector2.zero ;
                tap = false;
            }
        }
        Swipe = Handle.position - Joystick.position;
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(Swipe.normalized.x*MoveingSpeed, Swipe.normalized.y*MoveingSpeed);
        
        CameraScript.Instance.PositionCamera(Swipe,tap);
        
    }


    public void Reset()
    {
        
       dir = new Vector3(Player.transform.position.x, 0, Player.transform.position.z - 20) - Camera.main.transform.position;
    }
}
