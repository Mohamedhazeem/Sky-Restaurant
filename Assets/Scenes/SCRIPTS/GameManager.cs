using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    /// <summary>
    /// Control ADS
    /// control EARNING COST 
    /// GameManager hold data about other manager for their need
    /// current index about Data in SO
    /// 
    ///
    /// </summary>

    public int KitchenCurrentIndex;
    public int StoreRoomCurrentIndex;
    public int ManagerRoomCurrentIndex;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);        
    }
    #region ScenePacks
    public ScenePack scenePack;
    public enum ScenePack
    {
        Res1,
        Res2
    }
    #endregion

}


