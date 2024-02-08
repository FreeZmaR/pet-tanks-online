    using UnityEngine;
    using UnityEngine.UI;

    public class SettingBody: MonoBehaviour
    {
        [SerializeField] private VolumeRate _volumeRate;

        public void Show()
        {
            _volumeRate.Show();
        }

        public void Hide()
        {
            _volumeRate.Hide();
        }
    }