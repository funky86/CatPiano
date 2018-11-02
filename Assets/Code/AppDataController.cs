using System;
using System.Collections.Generic;
using CatPiano.Data;
using UnityEngine;

namespace CatPiano {

    public class AppDataController : MonoBehaviour {

        [SerializeField] private AppData Data;
        
        [NonSerialized] public int GroupId;
        public int GroupsCount {
            get {
                return _GroupsCount;
            }
        }

        private Dictionary<int, GroupData> CachedGroups = new Dictionary<int, GroupData>();
        private int _GroupsCount = 0;

        public void InitCache() {
            _GroupsCount  = 0;
            foreach (var group in Data.Groups) {
                group.InitCache();
                CachedGroups.Add(group.Id, group);
                _GroupsCount ++;
            }
        }

        public AudioClip GetAudioClip(KeyType type) {
            var group = CachedGroups[GroupId];
            return group.CachedKeys[type];
        }

        public String GetGroupName() {
            var group = CachedGroups[GroupId];
            return group.Name;
        }

    }

}
