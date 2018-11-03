using System;
using UnityEngine;
using Object = System.Object;

namespace CatPiano.Data {

    [Serializable]
    public class BgMusicData : Object {

        public String Name;
        public AudioClip AudioClip;
        
        [HideInInspector] public int Id; // must not be edited by the user, it's calculated in OnValidate()

    }

}
