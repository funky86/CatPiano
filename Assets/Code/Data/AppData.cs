using System.Collections.Generic;
using UnityEngine;

namespace CatPiano.Data {

    [CreateAssetMenu(fileName = "AppData", menuName = "CatPiano/AppData", order = 1)]
    public class AppData : ScriptableObject {

        public List<GroupData> Groups;

        private void OnValidate() { // auto generated data, not edited by the user
            int groupId = 1;
            foreach (var group in Groups) {
                foreach (var key in group.Keys) {
                    key.KeyName = key.Key.ToString();
                }
                group.Id = groupId++;
            }
        }

    }

}
