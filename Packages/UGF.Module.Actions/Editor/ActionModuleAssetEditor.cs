using UGF.Application.Editor;
using UGF.EditorTools.Editor.IMGUI.AssetReferences;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Actions.Runtime;
using UnityEditor;

namespace UGF.Module.Actions.Editor
{
    [CustomEditor(typeof(ActionModuleAsset), true)]
    internal class ActionModuleAssetEditor : ApplicationModuleAssetEditor
    {
        private SerializedProperty m_propertyScript;
        private AssetReferenceListDrawer m_listGroups;
        private AssetReferenceListDrawer m_listSystems;

        private void OnEnable()
        {
            m_propertyScript = serializedObject.FindProperty("m_Script");
            m_listGroups = new AssetReferenceListDrawer(serializedObject.FindProperty("m_groups"));
            m_listSystems = new AssetReferenceListDrawer(serializedObject.FindProperty("m_systems"));

            m_listGroups.Enable();
            m_listSystems.Enable();
        }

        private void OnDisable()
        {
            m_listGroups.Disable();
            m_listSystems.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(m_propertyScript);
                }

                m_listGroups.DrawGUILayout();
                m_listSystems.DrawGUILayout();
            }

            DrawModuleRegisterTypeInfo();
        }
    }
}
