using UnityEngine;

public class GameController : MonoBehaviour
{
    public int _coinNum {  get; private set; }

    public void IncrementCoin()
    {
        _coinNum++;
    }
}
