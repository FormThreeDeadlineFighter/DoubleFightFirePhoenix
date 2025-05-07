using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        UIController.current.OnCoinCollect += CoincoinCollect;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.current.CoinCollect();
        }
    }

    public void CoincoinCollect()
    {
        print("coin collect");
        Destroy(gameObject);
    }
}
