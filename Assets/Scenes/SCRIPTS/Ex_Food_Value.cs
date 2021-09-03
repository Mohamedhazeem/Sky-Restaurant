using UnityEngine;
using UnityEngine.UI;
 public class Ex_Food_Value : MonoBehaviour
 {
    public Transform player;
    public Text text;
    public int i = 0;
    public bool food;
    private void Start()
    {
        food = true;
        Ex_Data data = SaveSystem.LoadEx();
        i = data.ex_value;
        text.text = i.ToString();
    }
    private void Update()
    {
        //if (Vector3.Distance(player.transform.position, transform.position) < 2f)
        //{
            if (FoodPickUp_Agent.isFoodCloseToPlayer)
            {
                if (food)
                {
                 i += 1;
                 text.text = i.ToString();
                 SaveSystem.SaveEx(this);
                 food = false;
                }
            }
        //}
    }
}

