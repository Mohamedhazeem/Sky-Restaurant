using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool OnGround;
   
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
            OnGround = true; 
           
    }
    private void OnCollisionExit(Collision collision)
    {
        OnGround = false;
    }




}
