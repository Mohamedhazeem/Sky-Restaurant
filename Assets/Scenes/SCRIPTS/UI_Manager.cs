using System;
using UnityEngine;
 public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    ///asiign ui string and button text from SO
    ///not able to dontDestroyOnLoad();
    /// interactable or non interactable button check by cost value
    /// GameManager holds the indexs;
    /// if(earning cost > than upgradecost) => UpgradeManager(assign suitable method based on index) =>
    ///  INDEX++ => UI_Manager.changeButtonUi(inde);
    ///
    ///
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
   
}

