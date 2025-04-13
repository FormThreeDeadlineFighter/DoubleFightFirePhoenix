using UnityEngine;
using UnityEngine.UI;

public class CrosshairControl : MonoBehaviour
{
    [SerializeField] Image crosshair;
    [SerializeField] Transform _firePoint;
    //[SerializeField] Transform _raycastPoint;

    SinglePlayerControl pc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = GetComponent<SinglePlayerControl>();
        crosshair.transform.position = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 crossHairPosition = pc._playerLookPosition;
        
        crosshair.transform.position += new Vector3(crossHairPosition.x, crossHairPosition.y, 0) * 5;
        
        Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
        if(Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Vector3 targetPoint = hit.point;
            Debug.DrawLine(ray.origin, targetPoint, crosshair.color, 2f);
            
            if(hit.collider.tag == "Enemy")
            {
                Debug.Log("鎖定敵人");
            }
            
        }
    }
}
