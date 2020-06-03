using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class platesProtalUIIcons : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Type
    {
        Round,
        Square,
        Triangle
    };
    public Type type;

    public Sprite roundGrey;
    public Sprite roundGreen;
    public Sprite roundRed;

    public Sprite triangleGrey;
    public Sprite triangleGreen;
    public Sprite triangleRed;

    public Sprite squareGrey;
    public Sprite squareGreen;
    public Sprite squareRed;
    void Start()
    {
        if(type == Type.Round)
        {
            this.GetComponent<Image>().sprite = roundGrey;
        } 
        else if(type == Type.Square)
        {
            this.GetComponent<Image>().sprite = squareGrey;
        } 
        else if(type == Type.Triangle)
        {
            this.GetComponent<Image>().sprite = triangleGrey;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
