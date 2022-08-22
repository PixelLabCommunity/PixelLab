using UnityEngine;

public class InputConroler : MonoBehaviour
{
    //public static event OnSwipeInput SwipeEvent;
    //public delegate void OnSwipeInput(float speed);
    public static InputConroler Instation;

    [SerializeField] Arrow _arrow;
    [SerializeField] Car _car;

    private Vector2 tapPosition;
    private Vector2 swipeDelta;
    private Vector3 swipeHorizontal;

    private bool isSwipung;

    private int widthScreen;
    private int widthRight;
    public float speedcar;
    private void Start()
    {   
        isSwipung = false;
        widthScreen = Screen.width / 2;
        Instation = GetComponent<InputConroler>();
    } 
    private void Update()
    {    
        OnSwipe();
        OnSwipeHorizontally();
    }
    void OnSwipe()
    {     
        if (Input.touchCount > 0)
        {
            swipeHorizontal = Input.GetTouch(widthRight).position;         
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                isSwipung = true;
                tapPosition = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                swipeDelta = Input.GetTouch(0).position - tapPosition;

                if (Input.GetTouch(0).position.y < tapPosition.y)
                {
                    if (Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x))
                    {
                        //SwipeEvent(swipeDelta.magnitude);
                        speedcar = swipeDelta.magnitude;
                        ResetSwipe();                      
                    }
                }
            }else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                   ResetSwipe();
        }
    }
    void OnSwipeHorizontally()
    {
        int z =1;
        if (isSwipung)
        {
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            {
                if (swipeHorizontal.x > widthScreen)
                {
                    _arrow.RotationArrow(-z);
                    _car.OnRotationCar(-z);
                }
                else
                {
                    _arrow.RotationArrow(z);
                    _car.OnRotationCar(z);
                }
            }
        }
    }
    void ResetSwipe()
    {
        isSwipung = false;
        tapPosition = Vector2.zero;
        swipeDelta = Vector2.zero;
    }
 }
