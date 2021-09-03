using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("COMPONENTS")]
    public Swipe swipe;
    public GroundCheck groundCheck;
    private Rigidbody rb;
    private Raycast raycast;

    public static bool has_Player_Clamped;
    bool has_Player_Hit_By_Enemy;    

   // private bool isPlayerCentred;

    // TRY SCRIPTABLE OBJECTS FOR THE DATA
    [Header("Fall Speed")]
    [SerializeField][Range(0f, 1f)]
    private float fallSpeed;

    [Header("Slope Speed")]
    [SerializeField][Range(1f,200f)]
    float slopeSpeed;
    private float Slope_Current_Speed;
    private float Slope_Half_Speed;

    [Header("Run Speed")]
    [SerializeField][Range(0f,500f)]  //130 300f
    float Real_Speed;
    private float Current_Speed;
    private float Half_Speed;
    
    [Header("Punch Force")]
    [SerializeField][Range(1f, 500f)]  // 150
    float Punching_Force;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
        raycast = GetComponent<Raycast>();
        swipe = FindObjectOfType<Swipe>().GetComponent<Swipe>();


        // CLAMP PLAYER POSITION
        has_Player_Clamped = true;
        has_Player_Hit_By_Enemy = false;
        //isPlayerCentred = false;

        // SPEED CHANGES
        Current_Speed = Real_Speed;
        Half_Speed = Current_Speed / 2f;

        //SLOPE SPEED CHANGES
        Slope_Current_Speed = slopeSpeed;
        Slope_Half_Speed = Slope_Current_Speed / 2f;
    }
    
    private void FixedUpdate()
    {
        //if (isPlayerCentred == false) {
        //    if (SwipeTriggerZone.isTimeToCentre)
        //    {
        //        var centre_position = Mathf.Lerp(transform.position.x, 3, 0.5f);
        //        var pos = transform.position;
        //        pos.x = centre_position;
        //        transform.position = pos;
        //        if (transform.position.x == 3f)
        //            isPlayerCentred = true;
        //    } 
        //}
        //if (transform.position.x <= 3f)
        //{
        //    isPlayerCentred = false;
        //}
      
        #region Ground_Check
        if (groundCheck.OnGround && Swipe.hasSwipe )
        {

            if (has_Player_Hit_By_Enemy == false)
            {
                rb.velocity = Vector3.forward * Current_Speed * Time.deltaTime;
                if (raycast.IsRightSlope)
                    rb.velocity = new Vector3(0, raycast.hit.normal.y * Slope_Current_Speed, 1 * Current_Speed)  * Time.deltaTime;
                else if (raycast.IsLeftSlope)
                    rb.velocity = new Vector3(0, -(raycast.hit.normal.y) * Slope_Current_Speed, 1 * Current_Speed)  * Time.deltaTime;
            }

            if (has_Player_Hit_By_Enemy == true)
            {
                rb.constraints = RigidbodyConstraints.None;
            }           
        }

        else if (!groundCheck.OnGround && Swipe.hasSwipe)
        {
            
            var pos = transform.position;
             pos.y -= fallSpeed;   //0.125f
             transform.position = pos; 

            if (has_Player_Hit_By_Enemy == true)
            {
                rb.constraints = RigidbodyConstraints.None;
            }
        }    
        #endregion
        
    }
    private void Update()
    {
        //if (has_Player_Clamped)
        //{
        //    Vector3 pos = transform.position;
        //    pos.x = Mathf.Clamp(transform.position.x, 1f, 5f);
        //    transform.position = pos;
        //}
        #region SwipeControls

        if (swipe.SwipeLeft)
        {
            //if (transform.position.x > 1.1f)
              transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
           
        }
        else if (swipe.SwipeRight)
        {
            //if(transform.position.x < 4.9f)
            transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);
        }
        if (swipe.SwipeUp)
        {
            Current_Speed =Real_Speed;
            Slope_Current_Speed = slopeSpeed;
            //Debug.Log("SwipeUp");
        }
        else if(swipe.SwipeDown)
        {
            Current_Speed = Half_Speed;
            Slope_Current_Speed = Slope_Half_Speed;
           // Debug.Log("SwipeDown");
        }
        #endregion  
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.collider.CompareTag("Enemy"))
        {
           // has_Player_Clamped = false;
            has_Player_Hit_By_Enemy = true;
            Swipe.hasSwipe = false; 

           // rb.constraints = RigidbodyConstraints.None;

            Vector3 direction = (this.transform.position - collision.transform.position);
            direction.Normalize();
            rb.AddForce(direction*Punching_Force, ForceMode.Impulse); // 500 to 70     
        }
    }
}



