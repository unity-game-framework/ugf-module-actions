using UGF.Actions.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestActionCommandAsset")]
    public class TestActionCommandAsset : ActionAsset<TestActionCommandAction>
    {
    }

    public class TestActionCommandTarget
    {
        public int Counter { get; set; }
    }

    public readonly struct TestActionCommand : IActionCommand
    {
        public int Value { get; }

        public TestActionCommand(int value)
        {
            Value = value;
        }
    }

    public class TestActionCommandAction : Action<TestActionCommand>
    {
        protected override void OnExecute(IActionProvider provider, IActionContext context, TestActionCommand command)
        {
            if (context.TryGet(out TestActionCommandTarget target))
            {
                target.Counter += command.Value;
            }
        }
    }
}
