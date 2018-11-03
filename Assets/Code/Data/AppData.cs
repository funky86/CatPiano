using System.Collections.Generic;
using UnityEngine;

namespace CatPiano.Data {

    [CreateAssetMenu(fileName = "AppData", menuName = "CatPiano/AppData", order = 1)]
    public class AppData : ScriptableObject {

        [Header("Group data")]
        public List<GroupData> Groups;

        [Header("BG music data")]
        public List<BgMusicData> BgMusics;

        private void OnValidate() { // auto generated data, not edited by the user
            int id = 1;
            foreach (var group in Groups) {
                foreach (var key in group.Keys) {
                    key.KeyName = key.Key.ToString();
                }
                group.Id = id++;
            }
            id = 1;
            foreach (var bgMusic in BgMusics) {
                bgMusic.Id = id++;
            }
        }

    }

}
