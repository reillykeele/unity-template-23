using Util.Systems;
using Util.UI.Controllers.Selectables.Buttons;

namespace Template.UI.ButtonControllers
{
    public class ResumeGameButtonController : AButtonController
    {
        public override void OnClick() => GameSystem.Instance.ResumeGame();
    }
}
