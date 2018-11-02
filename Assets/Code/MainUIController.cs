using System;
using CatPiano.Data;
using UnityEngine;
using UnityEngine.UI;

namespace CatPiano {

    public class MainUIController : MonoBehaviour {

        [Header("Top panel")]
        [SerializeField] private Button ButtonGroupLeft;
        [SerializeField] private Text TextGroup;
        [SerializeField] private Button ButtonGroupRight;

        [Header("Keys")]
        [SerializeField] private Button ButtonC;
        [SerializeField] private Button ButtonCs;
        [SerializeField] private Button ButtonD;
        [SerializeField] private Button ButtonDs;
        [SerializeField] private Button ButtonE;
        [SerializeField] private Button ButtonF;
        [SerializeField] private Button ButtonFs;
        [SerializeField] private Button ButtonG;
        [SerializeField] private Button ButtonGs;
        [SerializeField] private Button ButtonA;
        [SerializeField] private Button ButtonAs;
        [SerializeField] private Button ButtonH;
        [SerializeField] private Button ButtonC2;

        [Header("Other")]
        [SerializeField] private AudioSource AudioSource;
        [SerializeField] private AppDataController AppDataController;

        private void Awake() {
            // buttons click callbacks
            ButtonC.onClick.AddListener(() => OnKeyPress(KeyType.C));
            ButtonCs.onClick.AddListener(() => OnKeyPress(KeyType.Cs));
            ButtonD.onClick.AddListener(() => OnKeyPress(KeyType.D));
            ButtonDs.onClick.AddListener(() => OnKeyPress(KeyType.Ds));
            ButtonE.onClick.AddListener(() => OnKeyPress(KeyType.E));
            ButtonF.onClick.AddListener(() => OnKeyPress(KeyType.F));
            ButtonFs.onClick.AddListener(() => OnKeyPress(KeyType.Fs));
            ButtonG.onClick.AddListener(() => OnKeyPress(KeyType.G));
            ButtonGs.onClick.AddListener(() => OnKeyPress(KeyType.Gs));
            ButtonA.onClick.AddListener(() => OnKeyPress(KeyType.A));
            ButtonAs.onClick.AddListener(() => OnKeyPress(KeyType.As));
            ButtonH.onClick.AddListener(() => OnKeyPress(KeyType.H));
            ButtonC2.onClick.AddListener(() => OnKeyPress(KeyType.C2));

            ButtonGroupLeft.onClick.AddListener(() => OnGroupChangePress(-1));
            ButtonGroupRight.onClick.AddListener(() => OnGroupChangePress(1));

            // the data
            AppDataController.InitCache();
            ShowGroup(1);
        }

        void ShowGroup(int id) {
            AppDataController.GroupId = id;
            TextGroup.text = AppDataController.GetGroupName();
        }

        void OnKeyPress(KeyType type) {
            AudioSource.clip = AppDataController.GetAudioClip(type);
            AudioSource.Play();
        }

        void OnGroupChangePress(int direction) {
            int groupId = AppDataController.GroupId;
            
            if (direction == -1) {
                groupId--;
            } else {
                groupId++;
            }
            
            groupId = Mathf.Clamp(groupId, 1, AppDataController.GroupsCount);
            
            ShowGroup(groupId);
        }

    }

}
