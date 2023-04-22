using UnityEngine;
using UnityEngine.Events;
using Util.Attributes;
using Util.Helpers;
using Util.UI.Controllers.Selectables.Buttons;
using Util.UI.Modals;

namespace Template.UI.ButtonControllers
{
    public class DisplayPopupModalButtonController : AButtonController
    {
        [SerializeField] [PrefabOnly] private ModalController _modalPrefab;

        [SerializeField] private string _modalTitle = "";
        [SerializeField] private string _modalDescription = "";

        public UnityEvent OnModalYesEvent = new UnityEvent();
        public UnityEvent OnModalNoEvent = new UnityEvent();

        private ModalController _modal;

        void Start()
        {
            _modal = Instantiate(_modalPrefab, _canvasController.transform);
            _modal.gameObject.Disable();
        }

        public override void OnClick()
        {
            StartCoroutine(_modal.DisplayModal(_modalTitle, _modalDescription, OnModalYesEvent.Invoke, OnModalNoEvent.Invoke));
        }

    }
}
