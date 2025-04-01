using UnityEngine;
using UnityEngine.UI;

public class CrosshairControl : MonoBehaviour
{
    [SerializeField] Image crosshair;

    SinglePlayerControl pc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = GetComponent<SinglePlayerControl>();
        crosshair.transform.position = Vector2.zero;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 crossHairPosition = pc._playerLookPosition;
        Debug.Log(crossHairPosition);
        crosshair.transform.position = crossHairPosition;
    }
}
