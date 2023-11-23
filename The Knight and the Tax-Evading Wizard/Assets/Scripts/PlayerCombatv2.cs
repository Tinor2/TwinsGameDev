using UnityEngine;

public class PlayerCombatv2 : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;


    private void Update()
    {
      if (timeBtwAttack <= 0) 
        {
            startTimeBtwAttack = timeBtwAttack;  
            if (Input.GetMouseButtonDown(0)) 
            {
            }
        } 
      else 
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
}
