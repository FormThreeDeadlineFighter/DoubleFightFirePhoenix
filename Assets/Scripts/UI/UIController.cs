using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_coinNumUI;

    public static UIController s_UIController;

    public int _coinNum { get; private set; }


    public event Action OnCoinCollect;

    private void Awake()
    {
        s_UIController = this;
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
