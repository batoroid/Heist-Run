using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    public CanvasGroup debugPanel;

    int debugCounter, themeCounter;

    public List<MeshRenderer> meshes;
    
    public List<Material> materials1;
    public List<Material> materials2;




    public void Mute()
    {
        SoundManager.instance.isMute = !SoundManager.instance.isMute;

    }



    public void DebugButton()
    {
        debugCounter++;

        if (debugCounter % 2 == 1)
        {
            debugPanel.alpha = 1;

            debugPanel.interactable = true;

            debugPanel.blocksRaycasts = true;

        }

        else
        {
            debugPanel.alpha = 0;

            debugPanel.interactable = false;

            debugPanel.blocksRaycasts = false;

        }

    }



    public void ThemeButton()
    {
        themeCounter++;

        meshes[0].material = materials1[themeCounter % 2];
        
        meshes[1].material = materials2[themeCounter % 2];

    }

}
