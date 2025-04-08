using UnityEditor;
using UnityEngine;

public class RemoveMissingScripts : MonoBehaviour
{
    [MenuItem("Tools/Remove Missing Scripts in Scene")]
    private static void RemoveMissingScriptsInScene()
    {
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        int removedCount = 0;

        foreach (GameObject obj in allObjects)
        {
            int count = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(obj);
            removedCount += count;
        }

        Debug.Log($"Removed {removedCount} missing scripts from the scene.");
    }
}