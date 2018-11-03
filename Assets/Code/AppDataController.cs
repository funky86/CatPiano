using System;
using System.Collections.Generic;
using System.Linq;
using CatPiano.Data;
using UnityEngine;

namespace CatPiano {

    public class AppDataController : MonoBehaviour {

        [SerializeField] private AppData Data;
        
        [NonSerialized] public int GroupId;
        [NonSerialized] public int BgMusicId;
        public int GroupsCount {
            get {
                return _GroupsCount;
            }
        }
        public int BgMusicsCount {
            get {
                return _BgMusicsCount;
            }
        }

        private Dictionary<int, GroupData> CachedGroups = new Dictionary<int, GroupData>();
        private Dictionary<int, BgMusicData> CachedBgMusics = new Dictionary<int, BgMusicData>();
        private int _GroupsCount = 0;
        private int _BgMusicsCount = 0;

        public void InitCache() {
            _GroupsCount  = Data.Groups.Count;
            foreach (var group in Data.Groups) {
                group.InitCache();
                CachedGroups.Add(group.Id, group);
            }
            _BgMusicsCount = Data.BgMusics.Count;
            foreach (var bgMusic in Data.BgMusics) {
                CachedBgMusics.Add(bgMusic.Id, bgMusic);
            }
        }

        public AudioClip GetGroupAudioClip(KeyType type) {
            var group = CachedGroups[GroupId];
            return group.CachedKeys[type];
        }

        public String GetGroupName() {
            var group = CachedGroups[GroupId];
            return group.Name;
        }

        public AudioClip GetBgMusicAudioClip() {
            var bgMusic = CachedBgMusics[BgMusicId];
            return bgMusic.AudioClip;
        }
        
        public String GetBgMusicName() {
            BgMusicData data;
            if (CachedBgMusics.TryGetValue(BgMusicId, out data)) {
                return data.Name;
            } else {
                return String.Empty;
            }
        }

    }

}
