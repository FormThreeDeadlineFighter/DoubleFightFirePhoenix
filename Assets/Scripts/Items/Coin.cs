using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.current.OnCoinCollect += CoinCollect;
            UIController.current.CoinCollect();
            UIController.current.OnCoinCollect -= CoinCollect;
        }
    }

    public void CoinCollect()
    {
        print("coin collect");
        Destroy(gameObject);
    }
}
