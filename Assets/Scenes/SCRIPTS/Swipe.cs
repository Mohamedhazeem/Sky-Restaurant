using UnityEngine;

public class Swipe : MonoBehaviour
{
    #region variables
    private Vector2 _StartTouchPosition, _EndTouchPosition;

    public static Transform FoodTransform;
    public static Transform RestaurantRoomsTransform;

    public static Vector3 FoodPositon; 
    public static Vector3 RestaurantRoomsPositon;

    private Ray ray;

    private float TouchStartTime, TouchEndTime;

    private bool _SwipeLeft, _SwipeRight , _SwipeUp, _SwipeDown;
    
    #region properties
    public bool SwipeLeft { get { return _SwipeLeft; } }
    public bool SwipeRight { get { return _SwipeRight; } }
    public bool SwipeUp { get { return _SwipeUp; } }
    public bool SwipeDown { get { return _SwipeDown; } }

    #endregion
    public bool IsDragging ;
    public static bool hasSwipe;
    public static bool isFood;
    #endregion

    private void Start()
    {
        isFood = false;
        //hasSwipe = true;
        hasSwipe = false;
    }
    public void Reset()
    {
        _StartTouchPosition = _EndTouchPosition = Vector2.zero;
        IsDragging = false;
      
    }
    public void RestaurantRoomsSelection(Ray ray)
    {
        if(TouchEndTime-TouchStartTime < 0.3f)
        {
                RaycastHit RestaurantRoomsHit;
            if (Physics.Raycast(ray, out RestaurantRoomsHit, 200f))
            {
                if (RestaurantRoomsHit.transform.CompareTag("KitchenRoom"))
                {
                    RestaurantRoomsTransform = RestaurantRoomsHit.transform;
                    RestaurantRoomsPositon = RestaurantRoomsHit.transform.position;
                    Debug.Log("Its KitchenRoom");
                }
                else if (RestaurantRoomsHit.transform.CompareTag("StoreRoom"))
                {
                    RestaurantRoomsTransform = RestaurantRoomsHit.transform;
                    RestaurantRoomsPositon = RestaurantRoomsHit.transform.position;
                    Debug.Log("Its StoreRoom");
                }

                else if (RestaurantRoomsHit.transform.CompareTag("ManagerRoom"))
                {
                    RestaurantRoomsTransform = RestaurantRoomsHit.transform;
                    RestaurantRoomsPositon = RestaurantRoomsHit.transform.position;
                    Debug.Log("Its MnagerRoom");
                }
            }
            
            
        }
    }
    private void Update()
    {
        _SwipeLeft = _SwipeRight = _SwipeUp = _SwipeDown = false;

        // TODO : MOBILE TOUCH
        #region MobileTouch
        if (Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                TouchStartTime = Time.time;

                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit foodHit;
                if (Physics.Raycast(ray,out foodHit,100f))
                {
                    if (foodHit.transform.CompareTag("Food")) 
                    {
                        FoodTransform = foodHit.transform;
                        FoodPositon =  foodHit.transform.position;
                        isFood = true;
                    }
                }
                else isFood = false;
                              
                IsDragging = true;
                _StartTouchPosition = Input.touches[0].position;
            }
            if(Input.touches[0].phase == TouchPhase.Ended ||Input.touches[0].phase == TouchPhase.Canceled)
            {
                TouchEndTime = Time.time;
                RestaurantRoomsSelection(ray);
                Reset();
            }        
        }
        #endregion

        _EndTouchPosition = Vector2.zero;
        if (IsDragging)
        {
            if (hasSwipe)
            {
                _EndTouchPosition = Input.touches[0].position - _StartTouchPosition;
                if (_EndTouchPosition.magnitude > 125) // 125 [pixel value]
                {


                    float x = _EndTouchPosition.x;
                    float y = _EndTouchPosition.y;

                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        //HORIZONTAL
                        if (x < 0)
                        {
                            _SwipeLeft = true;

                        }
                        else
                        {
                            _SwipeRight = true;

                        }
                    }
                    else if (Mathf.Abs(x) < Mathf.Abs(y))
                    {
                        // vertical
                        if (y > 0)
                        {
                            _SwipeUp = true;
                        }
                        else
                        {
                            _SwipeDown = true;
                        }
                    }
                    Reset();
                }
            }

        }

    }

}
