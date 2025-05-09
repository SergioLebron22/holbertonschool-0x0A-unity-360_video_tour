using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextButtonManager : MonoBehaviour
{
    public Image wallImage;
    public Image entranceImage;
    public Image cubeImage;
    public Image cantinaImage;
    public Image mezzanineImage1;
    public Image mezzanineImage2;

    public void ToggleImage(Image img) {
        if (img.gameObject.activeInHierarchy == true) {
            img.gameObject.SetActive(false);
        }
        else {
            img.gameObject.SetActive(true);
        }
    }

    public void OnWallClick() {
        ToggleImage(wallImage);
    }

    public void OnEntranceClick() {
        ToggleImage(entranceImage);
    }

    public void OnCubeClick() {
        ToggleImage(cubeImage);
    }

    public void OnCantinaClick() {
        ToggleImage(cantinaImage);
    }

    public void OnMezzanine1Click() {
        ToggleImage(mezzanineImage1);
    }

    public void OnMezzanine2Click() {
        ToggleImage(mezzanineImage2);
    }
}
