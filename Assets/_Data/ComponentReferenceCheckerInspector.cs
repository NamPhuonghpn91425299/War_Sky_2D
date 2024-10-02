using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ComponentReferenceChecker
{
    [MenuItem("CONTEXT/Component/Check References")]
    static void CheckReferences(MenuCommand command)
    {
        Component targetComponent = (Component)command.context;
        string targetTypeName = targetComponent.GetType().Name;
        List<(GameObject obj, Component comp)> referencingComponents = new List<(GameObject, Component)>();

        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            Component[] components = obj.GetComponents<Component>();
            foreach (Component component in components)
            {
                if (component == targetComponent) continue;

                SerializedObject serializedObject = new SerializedObject(component);
                SerializedProperty property = serializedObject.GetIterator();

                while (property.NextVisible(true))
                {
                    if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == targetComponent)
                    {
                        referencingComponents.Add((obj, component));
                        break;
                    }
                }
            }
        }

        if (referencingComponents.Count == 0)
        {
            Debug.Log($"No references found for {targetTypeName} in the current scene.");
        }
        else
        {
            Debug.Log($"Found {referencingComponents.Count} references to {targetTypeName}:");
            foreach (var (obj, comp) in referencingComponents)
            {
                string activeStatus = obj.activeInHierarchy ? "Active" : "Inactive";
                //Debug.Log($"{obj.name} ({activeStatus}) - {comp.GetType().Name}", obj);
                Debug.Log($"<color=gray>{obj.name}</color> ({activeStatus}) : <color=yellow>{comp.GetType().Name}</color>", obj);

            }
            //// Nhảy đến vị trí của component đầu tiên trong danh sách
            //if (referencingComponents.Count > 0)
            //{
            //    Selection.activeGameObject = referencingComponents[0].obj;
            //    SceneView.lastActiveSceneView.FrameSelected();
            //}
        }
    }
}