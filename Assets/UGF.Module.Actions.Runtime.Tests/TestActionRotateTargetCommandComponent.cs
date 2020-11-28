using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime.Tests
{
    public class TestActionRotateTargetCommandComponent : MonoBehaviour
    {
        [SerializeField] private Transform m_transform;
        [SerializeField] private Vector3 m_rotation;

        public Transform Transform { get { return m_transform; } set { m_transform = value; } }
        public Vector3 Rotation { get { return m_rotation; } set { m_rotation = value; } }

        private void Update()
        {
            if (ApplicationInstance.HasApplication)
            {
                var module = ApplicationInstance.Application.GetModule<IActionModule>();

                if (Input.GetKey(KeyCode.Space))
                {
                    module.Provider.Add(new TestActionRotateTargetCommand(m_transform, m_rotation));
                }
            }
        }
    }
}
