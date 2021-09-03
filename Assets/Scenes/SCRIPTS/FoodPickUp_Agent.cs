using UnityEngine;
using UnityEngine.AI;

public class FoodPickUp_Agent : MonoBehaviour
{
    public static NavMeshAgent agent;

    [SerializeField] GameObject trigger;

    [SerializeField] Vector3 offset;

    public static bool isFoodCloseToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GameObject.Find("TriggerZone");
        isFoodCloseToPlayer = false;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
    }

    void Update()
    {
        if (Swipe.isFood)
        {
            if (isFoodCloseToPlayer == false)
            {
                agent.SetDestination(Swipe.FoodPositon);
                //Player.has_Player_Clamped = false;
            }
            if (Vector3.Distance(Swipe.FoodPositon , transform.position)< 3f)
            {
                Swipe.FoodTransform.position = transform.position + Vector3.up * 3f;
                Swipe.FoodTransform.SetParent(this.transform);
                isFoodCloseToPlayer = true;
                    MoveTowardTrigger();                              
            }
        }
    }
    public void MoveTowardTrigger()
    {
        agent.SetDestination(trigger.transform.position);
    }
}
