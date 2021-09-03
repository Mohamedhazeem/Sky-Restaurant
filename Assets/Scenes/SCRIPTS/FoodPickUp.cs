using UnityEngine;

public class FoodPickUp : MonoBehaviour
{
    #region Variables
    public GameObject TriggerZone;

    public bool isFoodCloseToPlayer;
    public bool isNeedTo_Rotate_And_Move_Toward_TriggerZone;

    [Header("Turn and Move Speed")]
    [SerializeField] [Tooltip("5 in Prototype")]
    float Turn_Speed;

    [SerializeField]
    float Move_Speed;

    [Header("Food distance and PickUp time!")]
    [SerializeField][Range(0f,3f)]
    float FoodCloseDistance;

    [SerializeField] [Range(0f, 3f)]
    float FoodPickUpTime;
    #endregion
    private void Start()
    {
           isNeedTo_Rotate_And_Move_Toward_TriggerZone = true;
           isFoodCloseToPlayer = false;
    }
    private void Update()
    {
        if (Swipe.isFood )
        {
            RotateTowardFood();
            MoveTowardFood();
        }
        if (isFoodCloseToPlayer) 
        {          
            Swipe.FoodTransform.position = transform.position + Vector3.up * 3f;
            if (SwipeTriggerZone.IsPlayerOnSwipeTriggerZone == false)
            {
                RoatateToTriggerZone();
                MoveTriggerZone();
            }        
        }
    }

    public void RotateTowardFood()
    {        
        float dir_z = Swipe.FoodPositon.z - transform.position.z;
        float dir_x = Swipe.FoodPositon.x - transform.position.x;
        
        Quaternion rotation = Quaternion.LookRotation(new Vector3(dir_x, 0,dir_z));
        Debug.LogError(rotation);
        if (isFoodCloseToPlayer == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Turn_Speed * Time.deltaTime);
        }

    }
    public void MoveTowardFood()
    {
        float step = Move_Speed * Time.deltaTime; 
        Vector3 foodposition = new Vector3(Swipe.FoodPositon.x, 0, Swipe.FoodPositon.z);
        if(isFoodCloseToPlayer == false)
        transform.position = Vector3.MoveTowards(transform.position, foodposition, step);
  
        if (Vector3.Distance(transform.position, Swipe.FoodPositon) < FoodCloseDistance)
        {
            isFoodCloseToPlayer = true;
        }        
        
    }
    void RoatateToTriggerZone()
    {
        float dir_z = TriggerZone.transform.position.z - transform.position.z;
        float dir_x = TriggerZone.transform.position.x - transform.position.x;

        Quaternion rotation = Quaternion.LookRotation(new Vector3(dir_x, 0, dir_z));
            Debug.LogError(rotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Turn_Speed * Time.deltaTime);
    }
    void MoveTriggerZone()
    {
        float step = Move_Speed * Time.deltaTime;
            Vector3 TriggerPosition = new Vector3(TriggerZone.transform.position.x, 0, TriggerZone.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, TriggerPosition, step);
    }



}
