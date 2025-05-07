using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        UIController.s_UIController.OnCoinCollect += CoincoinCollect;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.s_UIController.CoinCollect();
        }
    }

    public void CoincoinCollect()
    {
        print("coin collect");
        Destroy(gameObject);
    }
}
