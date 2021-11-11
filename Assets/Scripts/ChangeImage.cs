using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField]
    Texture2D texture;
    private float _scale=1;
    private GameObject mayImage;
    private GameObject image;
    private Vector3 deltaPos;

    public float Scale { get => _scale<0?0:_scale; set => _scale = value; }

    public void ChangeCursor(GameObject nImage)
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
        mayImage = nImage;
    }
    public void ResetCursor(GameObject nImage)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        if (mayImage == nImage)
        {
            mayImage = null;
        }
    }
    private void Choose()
    {
        if (mayImage != null)
        {
            if(image==mayImage)
            {
                Vector3 pos = Input.mousePosition;
                image.transform.position = pos + deltaPos;
            }
        }
        else if (image)
        {
            image = null;
        }
    }
    private void ChangeScale(float delta)
    {
        if (delta == 0) return;
        if(image)
        {
            Scale += delta / 10;
            image.transform.localScale = new Vector3(Scale, Scale);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(image&&image!=mayImage)
            {
                image.GetComponent<Image>().color = Color.white;
            }
            if (mayImage)
            {
                image = mayImage;
                image.transform.SetSiblingIndex(image.transform.parent.childCount - 1);
                image.GetComponent<Image>().color = Color.red;
                Scale = image.transform.localScale.x;
                deltaPos = image.transform.position - Input.mousePosition;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0)) Choose();
        ChangeScale(Input.mouseScrollDelta.y);
    }
}
