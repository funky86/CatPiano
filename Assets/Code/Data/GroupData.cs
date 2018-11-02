using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace CatPiano.Data {

    [Serializable]
    public class GroupData : Object {

        public String Name;
        [HideInInspector] public int Id; // must not be edited by the user, it's calculated in OnValidate()
        public List<KeyData> Keys;

        [NonSerialized] public Dictionary<KeyType, AudioClip> CachedKeys = new Dictionary<KeyType, AudioClip>();

        public void InitCache() {
            foreach (var key in Keys) {
                CachedKeys.Add(key.Key, key.AudioClip);
            }
        }

    }

}
