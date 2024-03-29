﻿using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Actions.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestActionDescriptionAsset")]
    public class TestActionAsset : ActionDescribedAsset<TestAction, TestActionDescription>
    {
        [SerializeField] private int m_value;

        public int Value { get { return m_value; } set { m_value = value; } }

        protected override TestActionDescription OnBuildDescription()
        {
            return new TestActionDescription(m_value);
        }

        protected override TestAction OnBuild(TestActionDescription description, IApplication application)
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

        protected override void OnExecute(IActionProvider provider, IContext context)
        {
            if (context.TryGet(out TestActionTarget target))
            {
                target.Counter += Description.Value;
            }
        }
    }

    public class TestActionDescription : ActionDescription
    {
        public int Value { get; }

        public TestActionDescription(int value)
        {
            Value = value;
        }
    }
}
