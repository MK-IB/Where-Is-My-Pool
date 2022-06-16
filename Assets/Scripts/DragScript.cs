using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragScript : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    [SerializeField] private Vector3 gridSize;

    public bool isReflected;
    public bool isDraggable;
    
    private Vector3 originalScale;
    private Vector3 originalPos;

    private void Start()
    {
        /*float time = Random.Range(1f, 1.5f);
        StartCoroutine(ScaleUp(time));*/
        originalPos = transform.position;
    }

    IEnumerator ScaleUp(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.parent.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.25f);
        transform.DOScale(new Vector3(1.3f, 1.3f, 1), 0.5f).OnComplete(()=> {
            transform.parent = null;
        });
        //Vibration.Vibrate(27);
    }
    
    void OnMouseDown()
    {
        originalScale = transform.localScale;
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPos();
        offset.y = 0;
        transform.DOScale(new Vector3(originalScale.x + 0.25f, originalScale.y + 0.25f,originalScale.z), 0.15f).OnComplete(() =>
        {
            //transform.DOScale(originalScale, 0.1f);
        });
        //SoundManager.instance.PlayClip(SoundManager.instance.blockTouch);
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (isDraggable)
        {
            Vector3 movePos = GetMouseWorldPos();
            //movePos.y = originalPos.y;
            transform.position = movePos + offset;
            //SnapToGrid();
        }
    }
    private void OnMouseUp()
    {
        transform.DOScale(originalScale, 0.15f);
    }

    void SnapToGrid()
    {
        Vector3 pos = new Vector3(
            Mathf.Round(transform.position.x / gridSize.x) * gridSize.x, transform.position.y,transform.position.z);
        transform.position = pos;
    }

    void Disappear()
    {
        if (!isReflected)
        {
            transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }

    void StopDragging()
    {
        isDraggable = false;
    }
}
