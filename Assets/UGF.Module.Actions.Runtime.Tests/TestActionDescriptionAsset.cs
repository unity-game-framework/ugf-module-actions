using UGF.Actions.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestActionDescriptionAsset")]
    public class TestActionDescriptionAsset : ActionDescriptionAssetBase
    {
        protected override IActionDescription OnBuild()
        {
            return new TestActionDescription();
        }
    }

    public class TestAction : ActionDescribed<TestActionDescription>
    {
        public TestAction(TestActionDescription description) : base(description)
        {
        }

        protected override void OnExecute(IActionProvider provider, IActionContext context)
        {
        }
    }

    public class TestActionDescription : ActionDescriptionBase
    {
        protected override IAction OnBuild()
        {
            return new TestAction(this);
        }
    }
}
