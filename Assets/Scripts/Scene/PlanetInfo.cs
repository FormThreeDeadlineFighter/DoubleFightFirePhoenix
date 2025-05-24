using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new image", menuName = "PrizeImage")]
public class PlanetInfo : ScriptableObject
{
    public Sprite _image;
    public string _name;
    public int _num;
}
