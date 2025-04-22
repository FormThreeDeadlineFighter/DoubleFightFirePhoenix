using UnityEngine;
using UnityEngine.UI;

public class CrosshairControl : MonoBehaviour
{
    [SerializeField] Image crosshair;
    [SerializeField] Transform _firePoint;
    [SerializeField] float _rayRange;
    SinglePlayerControl pc;
    public Vector3 targetPoint;
    //public bool IsLocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = GetComponent<SinglePlayerControl>();
        //IsLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 crossHairPosition = pc._playerLookPosition;
        
        crosshair.transform.position += new Vector3(crossHairPosition.x, crossHairPosition.y, 0) * 5;
        
        Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
        if(Physics.Raycast(ray, out RaycastHit hit, _rayRange))
        {          
            if(hit.collider.tag == "Enemy")
            {
                targetPoint = hit.point;
                Debug.DrawLine(ray.origin, targetPoint, crosshair.color, 1f);
                return;
            }   
            
        }
        targetPoint = ray.GetPoint(_rayRange);        
    }
}
