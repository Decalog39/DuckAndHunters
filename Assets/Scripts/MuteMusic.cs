using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Music {
public class MuteMusic : MonoBehaviour
{
    bool isMute;

    public void Mute()
    {
        if (AudioListener.volume == 0) 
            AudioListener.volume = 1;
        else
        {
            AudioListener.volume = 0;
        }

    }

}

}

