using UnityEngine;
using UnityEngine.InputSystem;
using Util.UI;
using Util.UI.Controllers;

namespace UI.UIControllers
{
    public class StartMenuUIController : UIController
    {
        [Header("Start Menu UI Controller")]
        public UIPage TargetUiPageType;

        protected override void Awake()
        {
            base.Awake();

            // GameManager.Instance.CurrentGameState = GameState.Menu;
        }

        void OnEnable()
        {
            // TODO Bind to start button event
        }

        void OnDisable()
        {
            // TODO Un-bind to start button event
        }

        void Update()
        {
            // TODO: Use Input System
            if (Keyboard.current?.anyKey.wasPressedThisFrame == true ||
                Gamepad.current?.startButton.wasPressedThisFrame == true ||
                Mouse.current?.leftButton.wasPressedThisFrame == true)
            {
                // _canvasAudioController.Play(CanvasAudioController.CanvasAudioSoundType.Start);
                _canvasController.SwitchUI(TargetUiPageType, true);
            }
        }
    }
}
