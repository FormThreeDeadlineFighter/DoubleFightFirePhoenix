using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[ExecuteInEditMode]
public class AISensor : MonoBehaviour
{
    [SerializeField] float _distance = 10f;
    [SerializeField] float _angle= 30f;
    [SerializeField] float _height = 10f;
    [SerializeField] Color _meshColor = Color.red;
    [SerializeField] int _scanFrequrncy = 30;
    [SerializeField] LayerMask _layers;
    [SerializeField] LayerMask _occlusionLayers;
    public List<GameObject> Objects = new List<GameObject>();
    
    
    Collider[] _colliders = new Collider[50];
    private Mesh _mesh;
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
        Vector3 direction = dest - origin;
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
        
        if(Physics.Linecast(origin, dest, _occlusionLayers))
        {
            return false;
        }
        
        return true;
    }

    Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();
        
        int segments = 10;
        int numTriangles = (segments * 4) + 2 + 2;
        int numVertices = numTriangles * 3;
        
        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];
        
        Vector3 center = Vector3.zero;
        Vector3 left = Quaternion.Euler(0, -_angle, 0) * Vector3.forward * _distance;
        Vector3 right = Quaternion.Euler(0, _angle, 0) * Vector3.forward * _distance;
        
        Vector3 bottomLeft = left - Vector3.up * _height;
        Vector3 bottomRight = right - Vector3.up * _height;
        
        Vector3 topLeft = left + Vector3.up * _height;
        Vector3 topRight = right + Vector3.up * _height; 
        
        int vert = 0;
        
        //left side
        vertices[vert++] = center;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;
        
        //right side       
        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = center;
        
        float currentAngle = -_angle;
        float deltaAngle = _angle * 2 / segments;
        
        for(int i = 0; i < segments; ++i)
        {
            left = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * _distance;
            right = Quaternion.Euler(0, currentAngle + deltaAngle, 0) * Vector3.forward * _distance;                    
            
            bottomLeft = left - Vector3.up * _height;
            bottomRight = right - Vector3.up * _height; 
            
            topLeft = left + Vector3.up * _height;
            topRight = right + Vector3.up * _height; 
            
            //far side
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;
            
            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;
            
            //top
            vertices[vert++] = center;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;
            
            //bottom     
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;
            vertices[vert++] = center;         
                  
            currentAngle += deltaAngle;          
        }
    
        for(int i = 0; i < numVertices; ++i)
        {
            triangles[i] = i;
        }
        
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        
        return mesh;
    }
    
    
    private void OnValidate()
    {
        _mesh = CreateWedgeMesh();
        _scanInterval = 1.0f / _scanFrequrncy;
    }
    
    void OnDrawGizmos()
    {
        if(_mesh)
        {
            Gizmos.color = _meshColor;
            Gizmos.DrawMesh(_mesh, transform.position, transform.rotation);        
        }
        
        Gizmos.DrawWireSphere(transform.position, _distance);
        Gizmos.color = Color.red;
        for(int i = 0; i < _count; ++i)
        {
            
            Gizmos.DrawSphere(_colliders[i].transform.position, 5f);
        }
        
        Gizmos.color = Color.green;
        foreach(var obj in Objects)
        {
            Gizmos.DrawSphere(obj.transform.position, 5f);
        }
    }
}
