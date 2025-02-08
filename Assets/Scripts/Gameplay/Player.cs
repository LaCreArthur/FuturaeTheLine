using UnityEngine;

public class Player : MonoBehaviour
{
    public static Transform Transform;
    void Awake() => Transform = transform;
}
