using UnityEngine;
using Cinemachine;

public class PanVirtualCamera : MonoBehaviour
{
    #region Variables
    [Header("Cameras")]
    public Camera CameraMain;
    [SerializeField] CinemachineVirtualCamera RestaurantVirtualCamera;

    public bool isForward, isBackward, isLeft, isRight;

    [Space(2f)]
    [Header("Variables")]
    public float groundZ = 0;
    public float camspeed;
    

    [Header("VirtualCameraPosition")]
    [SerializeField] Vector3 VirtualCameraPosition;

    private Vector3 touchStart;
    private Vector3 DirectionValue;
    private Vector3 VirtualCameraInstance;
   


    [Space(2f)]
    [Header("FORWARD X VALUE")]
    public float Forward_X;
    [Header("BACKWARD X VALUE")]
    public float Backward_X;
    [Header("LEFT z VALUE")]
    public float Left_Z;
    [Header("RIGHT z VALUE")]
    public float Right_Z;
    
    #endregion

    private void Start()
    {
        CameraMain = FindObjectOfType<Camera>();
        RestaurantVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        isForward = isBackward = isLeft = isRight = true;        
        RestaurantVirtualCamera.transform.position = VirtualCameraPosition;
        VirtualCameraInstance = RestaurantVirtualCamera.transform.position;        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(groundZ);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPosition(groundZ);
            DirectionValue = direction * Time.deltaTime * camspeed;
            VirtualCameraWithInRestaurant();
            VirtualCameraNearEdgeOfRestaurant();
        }
    }

    private void VirtualCameraNearEdgeOfRestaurant()
    {
        var v = RestaurantVirtualCamera.transform.position;
        if (!isForward)
        {
            VirtualCameraInstance.x = Forward_X;
            
            v.x = Forward_X;
            RestaurantVirtualCamera.transform.position = v;            
        }
        if (!isBackward)
        {
            VirtualCameraInstance.x = Backward_X;
            
            v.x = Backward_X;
            RestaurantVirtualCamera.transform.position = v;            
        }
        if (!isLeft)
        {
            VirtualCameraInstance.z = Left_Z;
           
            v.z = Left_Z;
            RestaurantVirtualCamera.transform.position = v;            
        }
        if (!isRight)
        {
            VirtualCameraInstance.z = Right_Z;
           
            v.z = Right_Z;
            RestaurantVirtualCamera.transform.position = v;            
        }
    }

    private void VirtualCameraWithInRestaurant()
    {
        
        VirtualCameraInstance += DirectionValue;       

        isForward = VirtualCameraInstance.x <= Forward_X ? true : false;

        isBackward = VirtualCameraInstance.x >= Backward_X ? true : false;

        isLeft = VirtualCameraInstance.z <= Left_Z ? true : false;

        isRight = VirtualCameraInstance.z >= Right_Z ? true : false;

        if (isForward)
            RestaurantVirtualCamera.transform.position += DirectionValue;
        else if (isBackward)
            RestaurantVirtualCamera.transform.position += DirectionValue;
        else if (isLeft)
            RestaurantVirtualCamera.transform.position += DirectionValue;
        else if (isRight)
            RestaurantVirtualCamera.transform.position += DirectionValue;
    }
    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = CameraMain.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        
        return mousePos.GetPoint(distance);
    }
}
