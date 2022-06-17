using UnityEngine;
using DG.Tweening;

public class ObstacleRotation : MonoBehaviour
{
    public Vector3 axis;
    public float speed;

    private void Start()
    {
        //Rotate();
    }

    private void Update()
    {
        transform.Rotate(axis * speed * Time.deltaTime, Space.Self);
    }
    void Rotate()
    {
        //transform.DOLocalRotate(angles, duration, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
    }

    
}
