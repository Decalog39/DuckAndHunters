using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Music
{
    public class ChangeImage : MonoBehaviour
{
    public Image oldImage;
    public Sprite newImage;
    // Start is called before the first frame update
    void Start()
    {
        if(AudioListener.volume == 0) {
            Sprite temp = oldImage.sprite;
            oldImage.sprite = newImage; 
            newImage = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImageChange() {
        Sprite temp = oldImage.sprite;
        oldImage.sprite = newImage; 
        newImage = temp;
    }

}
}


