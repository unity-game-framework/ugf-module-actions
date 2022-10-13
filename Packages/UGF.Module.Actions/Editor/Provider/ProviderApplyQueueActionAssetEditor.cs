using UGF.Module.Actions.Runtime.Provider;
using UnityEditor;

namespace UGF.Module.Actions.Editor.Provider
{
    [CustomEditor(typeof(ProviderApplyQueueActionAsset), true)]
    internal class ProviderApplyQueueActionAssetEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("Applies command queue in 'IActionProvider'.", MessageType.Info);
        }
    }
}
