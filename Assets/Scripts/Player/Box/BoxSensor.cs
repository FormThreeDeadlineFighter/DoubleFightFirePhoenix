using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BoxSensor : MonoBehaviour
{
    [SerializeField] float _distance = 10f;
    [SerializeField] Color _meshColor = Color.red;
    [SerializeField] int _scanFrequrncy = 30;
    [SerializeField] LayerMask _layers;
    [SerializeField] LayerMask _occlusionLayers;
    public List<GameObject> Objects = new List<GameObject>();
    
    
    Collider[] _colliders = new Collider[50];
    int _count;
    float _scanInterval;
    float _scanTimer;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _scanInterval = 1.0f / _scanFrequrncy;
    }

    // Update is called once per frame
    void Update()
    {
        _scanTimer -= Time.deltaTime;
        if(_scanTimer < 0)
        {
            _scanTimer += _scanInterval;
            Scan();
        }
    }

    private void Scan()
    {
        _count = Physics.OverlapSphereNonAlloc(transform.position, _distance, _colliders, _layers, QueryTriggerInteraction.Collide);
        
        Objects.Clear();
        for(int i = 0; i < _count; ++i)
        {
            GameObject obj = _colliders[i].gameObject;
            if(IsInSight(obj))
            {           
                Objects.Add(obj);
            }
        }
    }
    
    public bool IsInSight(GameObject obj)
    {   
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        /*Vector3 direction = dest - origin;
        if(direction.y < -_height || direction.y > _height)
        {
            return false;
        }
        
        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, transform.forward);
        if(deltaAngle > _angle)
        {
            return false;
        }       
        */
        if(Physics.Linecast(origin, dest, _occlusionLayers))
        {
            return false;
        }
        
        return true;
    }
    
    private void OnValidate()
    {
        _scanInterval = 1.0f / _scanFrequrncy;
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = _meshColor;
        Gizmos.DrawWireSphere(transform.position, _distance);
            Gizmos.color = Color.red;
            for(int i = 0; i < _count; ++i)
            {           
                Gizmos.DrawSphere(_colliders[i].transform.position, 5f);
            }
        
        if(Objects != null) 
        { 
            Gizmos.color = Color.green;
            foreach(GameObject obj in Objects)
            {
                Gizmos.DrawSphere(obj.transform.position, 5f);
            }
        }
    }
}
