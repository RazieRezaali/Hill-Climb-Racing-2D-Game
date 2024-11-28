using UnityEngine;

public class CollectGreenFuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Collision){
        if(Collision.gameObject.CompareTag("Player")){
            FuelController.instance.FillGreenFuel();
            Destroy(gameObject);
        }
    }
}
