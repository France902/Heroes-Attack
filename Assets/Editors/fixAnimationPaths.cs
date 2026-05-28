using UnityEngine;
using UnityEditor;

public class FixAnimationPaths : EditorWindow
{
    string oldPrefix = "";
    string newPrefix = "Busto/";

    [MenuItem("Tools/Fix Animation Paths")]
    static void Open() => GetWindow<FixAnimationPaths>("Fix Anim Paths");

    void OnGUI()
    {
        GUILayout.Label("Seleziona la AnimationClip nel Project", EditorStyles.boldLabel);
        oldPrefix = EditorGUILayout.TextField("Prefisso da sostituire:", oldPrefix);
        newPrefix = EditorGUILayout.TextField("Nuovo prefisso:", newPrefix);

        if (GUILayout.Button("Preview path attuali"))
        {
            AnimationClip clip = Selection.activeObject as AnimationClip;
            if (clip == null) { Debug.LogError("Seleziona prima una AnimationClip!"); return; }
            foreach (var b in AnimationUtility.GetCurveBindings(clip))
                Debug.Log(b.path);
        }

        if (GUILayout.Button("ESEGUI FIX"))
        {
            AnimationClip clip = Selection.activeObject as AnimationClip;
            if (clip == null) { Debug.LogError("Seleziona prima una AnimationClip!"); return; }

            int count = 0;
            foreach (var binding in AnimationUtility.GetCurveBindings(clip))
            {
                // Se oldPrefix è vuoto, aggiunge newPrefix a tutti
                if (string.IsNullOrEmpty(oldPrefix) || binding.path.StartsWith(oldPrefix))
                {
                    var curve = AnimationUtility.GetEditorCurve(clip, binding);
                    var newBinding = binding;
                    newBinding.path = newPrefix + binding.path.Substring(oldPrefix.Length);

                    AnimationUtility.SetEditorCurve(clip, binding, null);
                    AnimationUtility.SetEditorCurve(clip, newBinding, curve);
                    count++;
                }
            }
            Debug.Log($"Fixati {count} path!");
        }
    }
}