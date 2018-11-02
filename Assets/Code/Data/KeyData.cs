using System;
using UnityEngine;
using Object = System.Object;

namespace CatPiano.Data {

    [Serializable]
    public class KeyData : Object {

        [HideInInspector] public String KeyName; // just to show the key name in the Inspector instead of Element 0, etc.
        public KeyType Key;
        public AudioClip AudioClip;

    }

}
