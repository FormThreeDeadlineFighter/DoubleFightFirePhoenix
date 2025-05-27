using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_coinNumUI;
    public static UIController current;
    public int _coinNum { get; private set; }

    public event Action OnCoinCollect;
    //public event Action OnGameUI;

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {
        m_coinNumUI.text = _coinNum.ToString("00");
    }

    public void CoinCollect()
    {
        if(OnCoinCollect != null)
        {
            _coinNum++;
            OnCoinCollect();
        }       
    }

}
