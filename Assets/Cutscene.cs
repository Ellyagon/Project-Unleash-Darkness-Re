using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public static event Action<bool> OnCutscene;

    protected void CutsceneEvent(bool isPlaying)
    {
        OnCutscene.Invoke(isPlaying);
    }
}
