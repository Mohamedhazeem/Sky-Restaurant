using UnityEngine;
using UnityEngine.AI;

public class SwipeTriggerZone : MonoBehaviour
{
    Player player;

    public static bool IsPlayerOnSwipeTriggerZone;
    public static bool isTimeToCentre;
    
    private void Start()
    {
       // player = GetComponent<Player>();
        IsPlayerOnSwipeTriggerZone = false;
        isTimeToCentre = false;
    }
    private void OnTriggerEnter(Collider other)
    {
       if( other.gameObject.CompareTag("Player"))
       {
            FoodPickUp_Agent.agent.enabled = false;

           // isTimeToCentre = true;
            //Player.has_Player_Clamped = true;
            
            Swipe.hasSwipe = true;
            Debug.Log(Swipe.hasSwipe);

            this.gameObject.SetActive(false);
       }
       
       else
       {
            Swipe.hasSwipe = false;
            IsPlayerOnSwipeTriggerZone = false;
            Debug.Log(Swipe.hasSwipe);

            this.gameObject.SetActive(true);
        }
    }
}

