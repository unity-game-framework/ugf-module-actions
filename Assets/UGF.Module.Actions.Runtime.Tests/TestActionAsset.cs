using UGF.Actions.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestActionDescriptionAsset")]
    public class TestActionAsset : ActionDescribedAsset<TestActionDescription>
    {
        [SerializeField] private int m_value;

        public int Value { get { return m_value; } set { m_value = value; } }

        protected override TestActionDescription OnBuildDescription()
        {
            return new TestActionDescription(m_value);
        }

        protected override IAction OnBuild(TestActionDescription description)
        {
            return new TestAction(description);
        }
    }

    public class TestActionTarget
    {
        public int Counter { get; set; }
    }

    public class TestAction : ActionDescribed<TestActionDescription>
    {
        public TestAction(TestActionDescription description) : base(description)
        {
        }

        protected override void OnExecute(IActionProvider provider, IActionContext context)
        {
            if (context.TryGet(out TestActionTarget target))
            {
                target.Counter += Description.Value;
            }
        }
    }

    public class TestActionDescription : ActionDescriptionBase
    {
        public int Value { get; }

        public TestActionDescription(int value)
        {
            Value = value;
        }
    }
}
