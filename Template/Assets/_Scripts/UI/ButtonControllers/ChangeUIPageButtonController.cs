using Util.UI;
using Util.UI.Controllers.Selectables.Buttons;

namespace Template.UI.ButtonControllers
{
    public class ChangeUIPageButtonController : AButtonController
    {
        public UIPage TargetUiPage;

        public override void OnClick()
        {
            _canvasController.SwitchUI(TargetUiPage);
        }
    }
}