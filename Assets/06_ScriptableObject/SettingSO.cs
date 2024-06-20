using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingSO", menuName = "SO/SettingSO")]
public class SettingSO : ScriptableObject
{
    public float bgmValue;
    public float sfxValue;
    public FPSType fpsType;
}
