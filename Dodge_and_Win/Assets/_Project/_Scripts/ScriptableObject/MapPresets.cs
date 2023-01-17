using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/MapPresets")]
public class MapPresets : ScriptableObject
{
    public Sprite Background;
    public AudioClip Clip;
    public GameObject Enemy;
    public GameObject Player;
}
