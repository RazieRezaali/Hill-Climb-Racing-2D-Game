using UnityEngine;

public class CollectRedFuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Collision){
        if(Collision.gameObject.CompareTag("Player")){
            FuelController.instance.FillRedFuel();
            Destroy(gameObject);
        }
    }
}
