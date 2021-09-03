using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public  void SceenSwitch()
    {
        if (SceneManager.sceneCountInBuildSettings < 2)
            GameManager.instance.scenePack = GameManager.ScenePack.Res1;
        else
            GameManager.instance.scenePack = GameManager.ScenePack.Res2;
        
        switch (GameManager.instance.scenePack)
        {
            case GameManager.ScenePack.Res1:
                var Res1_Scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(Res1_Scene+1);
                Debug.Log("res1 loaded");
                break;
            case GameManager.ScenePack.Res2:
                var Res2_Scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(Res2_Scene + 1);
                Debug.Log("new res loaded");
                break;
        }
    }
}

