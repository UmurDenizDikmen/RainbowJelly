using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTableJelly : MonoBehaviour
{
    [SerializeField] private Color [] myColor;
    public enum  typeOfJelly
    {
        red,
        blue,
        yellow,
        orange,
        purple,
        green
        
    }
    [SerializeField]private typeOfJelly jellyType;
    void Start()
    {
        
    }
     
    private void OnMouseDown()
    {
        if(jellyType == typeOfJelly.red)
        { 
             if(GameManager.instance.jellyImagesList[0].GetComponent<Image>().color == myColor[2])
             {
                transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[3]; 
                jellyType = typeOfJelly.purple;
             }
             else if(GameManager.instance.jellyImagesList[0].GetComponent<Image>().color == myColor[1])
             {
                transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[4];  
                jellyType = typeOfJelly.orange;

             }
        }
      
    }
    
        
    
    

   
   
}
