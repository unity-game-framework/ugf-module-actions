using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Actions.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestActionRotateTargetDescriptionAsset")]
    public class TestActionRotateTargetAsset : ActionDescribedAsset<TestActionRotateTarget, TestActionRotateTargetDescription>
    {
        [SerializeField] private float m_speed = 1F;

        public float Speed { get { return m_speed; } set { m_speed = value; } }

        protected override TestActionRotateTargetDescription OnBuildDescription()
        {
            return new TestActionRotateTargetDescription(m_speed);
        }

        protected override TestActionRotateTarget OnBuild(TestActionRotateTargetDescription description, IApplication application)
        {
            return new TestActionRotateTarget(description);
        }
    }

    public class TestActionRotateTargetDescription : ActionDescription
    {
        public float Speed { get; }

        public TestActionRotateTargetDescription(float speed)
        {
            Speed = speed;
        }
    }

    public class TestActionRotateTarget : ActionDescribed<TestActionRotateTargetDescription, TestActionRotateTargetCommand>
    {
        public TestActionRotateTarget(TestActionRotateTargetDescription description) : base(description)
        {
        }

        protected override void OnExecute(IActionProvider provider, IContext context, TestActionRotateTargetCommand command)
        {
            command.Transform.Rotate(command.Rotation * Description.Speed * Time.deltaTime);
        }
    }

    public readonly struct TestActionRotateTargetCommand : IActionCommand
    {
        public Transform Transform { get; }
        public Vector3 Rotation { get; }

        public TestActionRotateTargetCommand(Transform transform, Vector3 rotation)
        {
            Transform = transform ? transform : throw new ArgumentNullException(nameof(transform));
            Rotation = rotation;
        }
    }
}
