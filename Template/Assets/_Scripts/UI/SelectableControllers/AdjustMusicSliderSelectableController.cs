using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Util.Enums;
using Util.Systems;

namespace Template.UI.SelectableControllers
{
    public class AdjustMusicSliderSelectableController : AdjustValueSelectableController
    {
        [SerializeField] private AudioMixerGroupVolumeType _mixerGroup;

        [SerializeField] private Slider _slider;

        private float _direction;
        
        protected override void Start()
        {
            var vol = GetVolume();
            SetVolume(vol);

            _slider.onValueChanged.AddListener(SetVolumeFromSlider);
        }

        public override void OnSelect(BaseEventData eventData)
        {
            _inputReader.MenuNavigateEvent += StartNav;
            _inputReader.MenuNavigateCancelledEvent += StopNav;
        }

        public override void OnDeselect(BaseEventData eventData)
        {

            StopNav();

            _inputReader.MenuNavigateEvent -= StartNav;
            _inputReader.MenuNavigateCancelledEvent -= StopNav;
        }

        void Update()
        {
            if (_direction != 0)
            {
                _slider.value += _direction * _incrementValue * Time.deltaTime;
            }
        }

        private void StartNav(Vector2 nav)
        {
            if (nav == Vector2.left || nav == Vector2.right)
                _direction = nav.x;
        }

        private void StopNav()
        {
            _direction = 0f;
        }

        private float GetVolume()
        {
            var volName = _mixerGroup.ToString();
            GameSystem.Instance.Mixer.GetFloat(volName, out var vol);
            return vol;
        }

        private void SetMixerVolume(float vol)
        {
            var volName = _mixerGroup.ToString();
            GameSystem.Instance.Mixer.SetFloat(volName, vol);
        }

        private void SetVolume(float vol)
        {
            SetMixerVolume(vol);

            _value = vol + 80f;
            _slider.value = _value / 100f;
        }

        private void SetVolumeFromSlider(float value)
        {
            var vol = value * 100f - 80;

            Debug.Log(value + " " + vol);

            SetVolume(vol);
        }
    }
}