using UnityEngine;
using UnityEngine.UI;

public class ButtonToSceenChange : MonoBehaviour
{
     SceneLoader sceneLoader;
     Button button;
    // Start is called before the first frame update
    void Start()
    {
       // SceneLoader sceneLoader = FindObjectOfType<SceneLoader>().
         sceneLoader =   GetComponent<SceneLoader>();
         button = GetComponent<Button>();
         button.onClick.AddListener(sceneLoader.SceenSwitch);
        // always know to write code seperate;

    }

}
