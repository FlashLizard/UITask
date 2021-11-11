using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    private int _id=0;
    private Image image;

    public int Id { get => _id = (_id+5)%5; set => _id = value; }
    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }
    public void ChangeImage(int delta)
    {
        Id += delta;
        image.sprite = Resources.Load<Sprite>(@"Images\image_"+Id.ToString());
    }
    public void ChangeR(float value)
    {
        image.color = new Color(value,image.color.g,image.color.b);
    }
    public void ChangeG(float value)
    {
        image.color = new Color(image.color.r , value, image.color.b);
    }
    public void ChangeB(float value)
    {
        image.color = new Color(image.color.r, image.color.g, value);
    }
}
