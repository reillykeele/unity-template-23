using Util.UI.Controllers.Selectables.Buttons;

namespace Template.UI.ButtonControllers
{
    public class ReturnToPreviousButtonController : AButtonController
    {
        public override void OnClick()
        {
            _canvasController.ReturnToPrevious();
        }
    }
}
