using UnityEngine;

public class CollectGoldFuel : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D Collision){        
        if(Collision.gameObject.CompareTag("Player")){            
            FuelController.instance.FillGoldFuel();            
            Destroy(gameObject);
        }
    }
}
