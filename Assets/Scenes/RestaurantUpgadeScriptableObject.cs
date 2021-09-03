using UnityEngine;

[CreateAssetMenu(fileName = "RestaurantUpgadeScriptableObject",menuName = "ScriptableObject/RestaurantUpgadeScriptableObject")]
public class RestaurantUpgadeScriptableObject : ScriptableObject
{
    [Header("KITCHEN")]
    public KitchenUpGrade[] KitchenUpGrades;
    [Header("KITCHEN_UI")]
    public UIdata[] KitchenUIdatas;

    [Space(5f)]
    [Header("MANAGER_ROOM")]    
    public ManagerRoomUpGrade[] managerRoomUpGrades;
    [Header("MANAGER_UI")]
    public UIdata[] ManagerUIdatas;

    [Space(5f)]
    [Header("STORE_ROOM")]
    public StoreRoomUpGrade[] storeRoomUpGrades;
    [Header("STORE_UI")]
    public UIdata[] StoreUIdatas;
}
[System.Serializable]
public class KitchenUpGrade
{
    public bool isUnlocked;
    public int UpgradeCost;
    public GameObject[] ObjectsToShown;   
    public void KitchenObjectsToShown()
    {
        if (ObjectsToShown == null)
            return;
        
        foreach (var objects in ObjectsToShown)
        {
            objects.SetActive(true);
        }
        
    }
}
[System.Serializable]
public class UIdata
{
    public string name;
    public string text;
    public int[] UpgradeCost;
}
[System.Serializable]
public class ManagerRoomUpGrade
{
    public bool isUnlocked;
    public int UpgradeCost;
    public GameObject[] ObjectsToShown;
    public void ManagerRoomObjectsToShown()
    {
        if (ObjectsToShown == null)
            return;

        foreach (var objects in ObjectsToShown)
        {
            objects.SetActive(true);
        }

    }
}

[System.Serializable]
public class StoreRoomUpGrade
{
    public bool isUnlocked;
    public int UpgradeCost;
    public GameObject[] ObjectsToShown;
    public void StoreRoomObjectsToShown()
    {
        if (ObjectsToShown == null)
            return;

        foreach (var objects in ObjectsToShown)
        {
            objects.SetActive(true);
        }

    }
}
