using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Actions.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestActionCommandAsset")]
    public class TestActionCommandAsset : ActionAsset
    {
        protected override IAction OnBuild(IApplication arguments)
        {
            return new TestActionCommandAction();
        }
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

    public class TestActionCommandAction : UGF.Actions.Runtime.Action<TestActionCommand>
    {
        protected override void OnExecute(IActionProvider provider, IContext context, TestActionCommand command)
        {
            if (context.TryGet(out TestActionCommandTarget target))
            {
                target.Counter += command.Value;
            }
        }
    }
}
