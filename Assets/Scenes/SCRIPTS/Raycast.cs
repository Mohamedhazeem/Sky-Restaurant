using UnityEngine;
public class Raycast : MonoBehaviour
{
    private bool isRightSlope, isLeftSlope;
    public bool IsRightSlope { get { return isRightSlope; } }
    public bool IsLeftSlope { get { return isLeftSlope; } }

    public float distance;

    public RaycastHit hit;
    public bool Onslope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
            if (hit.normal != Vector3.up)
            {
                //Debug.Log(hit.normal);
                return true;
            }
            else
                isLeftSlope = isRightSlope = false;
       // Debug.Log($"right - {isRightSlope} , left - {isLeftSlope}");
        return false;
    }
    private void Update()
    {
        if (Onslope())
        {           
          // Debug.Log( hit.transform.localEulerAngles);
            if (hit.transform.localEulerAngles.x >= 90f)
                isRightSlope = true;
            else isRightSlope = false;
           // Debug.Log("right :" + isRightSlope);

            if (hit.transform.localEulerAngles.x <= 90f)
                isLeftSlope = true;
            else isLeftSlope = false;
            //Debug.Log("left :" + isLeftSlope);
            //Debug.Log(Vector3.Angle(transform.eulerAngles, hit.transform.eulerAngles));
            //Debug.Log(Quaternion.Angle(transform.localRotation,hit.transform.localRotation));

        }
    }

}
