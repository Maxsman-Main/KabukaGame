using UnityEngine;
using UnityEditor;
using Codice.Client.Common.GameUI;
using UnityEngine.Rendering;
using UnityEditor.PackageManager;

public class Randomizer : EditorWindow
{
    int randomX, randomY, randomZ;
    bool mirrorX, mirrorY, mirrorZ;
    [MenuItem("Utils/Randomiser")]
    // Start is called before the first frame update
    static void Init()
    {
        Randomizer window = (Randomizer)GetWindow(typeof(Randomizer));
        window.Show();
    }
    private void OnGUI()
    {
        GUILayout.Label("Add rotation to selected", EditorStyles.boldLabel);
        randomX = EditorGUILayout.IntSlider("Quater-Rotations on X", randomX, 0, 3);
        randomY = EditorGUILayout.IntSlider("Quater-Rotations on Y", randomY, 0, 3);
        randomZ = EditorGUILayout.IntSlider("Quater-Rotations on Z", randomZ, 0, 3);
        mirrorX = EditorGUILayout.Toggle("Mirror X", mirrorX);
        mirrorY = EditorGUILayout.Toggle("Mirror Y", mirrorY);
        mirrorZ = EditorGUILayout.Toggle("Mirror Z", mirrorZ);

        if (GUILayout.Button("Randomise Rotation"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                go.transform.rotation = Quaternion.Euler(GetRandomRotations(go.transform.rotation.eulerAngles));
            }
        }

        if (GUILayout.Button("Randomise Mirror"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                go.transform.localScale = GetRandomMirror(go.transform.localScale);
            }
        }
    }
    private Vector3 GetRandomRotations(Vector3 currentRotation)
    {
        float x = currentRotation.x + Random.Range(0, randomX + 1) * 90f;
        float y = currentRotation.y + Random.Range(0, randomY + 1) * 90f;
        float z = currentRotation.z + Random.Range(0, randomZ + 1) * 90f;

        return new Vector3(x, y, z);
    }
    private Vector3 GetRandomMirror(Vector3 currentScale)
    {
        float x = mirrorX ? Random.Range(0, 2) * 2 - 1 : currentScale.x;
        float y = mirrorY ? Random.Range(0, 2) * 2 - 1 : currentScale.y;
        float z = mirrorZ ? Random.Range(0, 2) * 2 - 1 : currentScale.z;

        return new Vector3(x, y, z);
    }
}
