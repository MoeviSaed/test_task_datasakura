using System;
using UnityEngine;

public class Readme : ScriptableObject
{
    [Serializable]
    public class Section
    {
        public string heading,
            text,
            linkText,
            url;
    }

    public Texture2D icon;
    public string title;
    public Section[] sections;
    public bool loadedLayout;
}
