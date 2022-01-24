using UnityEditor;
using UnityEngine;
using System;

#if UNITY_EDITOR
[CustomEditor(typeof(DemoEventsManager))]
public class DemoEventsManagerEditor : Editor
{
    // The various categories the editor will display the variables in
    public enum DisplayCategory
    {
        Local, Azure, AWS
    }


    public string Study;
    // The enum field that will determine what variables to display in the Inspector
    public DisplayCategory categoryToDisplay;

    public AWSRegionSystemName awsRegionSelected;

    // The function that makes the custom editor work
    public override void OnInspectorGUI()
    {

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("SessionNameForLog"));
        // Create a space to separate this enum popup from other variables 
        EditorGUILayout.Space();
        // Display the enum popup in the inspector
        categoryToDisplay = (DisplayCategory)EditorGUILayout.EnumPopup("Write Log to", categoryToDisplay);

        // Create a space to separate this enum popup from the other variables 
        EditorGUILayout.Space();
        //Switch statement to handle what happens for each category
        switch (categoryToDisplay)
        {
            case DisplayCategory.Local:
                DisplayLocalInfo();
                break;

            case DisplayCategory.Azure:
                DisplayAzureInfo();
                break;

            case DisplayCategory.AWS:
                DisplayAWSInfo();
                break;

        }
        serializedObject.ApplyModifiedProperties();
    }


    //When the categoryToDisplay enum is at "Basic"
    void DisplayAzureInfo()
    {
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ConnectionString"));
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("UploadFileType"));
        EditorGUILayout.Space();
    }

    //When the categoryToDisplay enum is at "Combat"
    void DisplayAWSInfo()
    {
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("AccessKey"));
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("SecretKey"));
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("BucketName"));
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("SessionToken"));
        EditorGUILayout.Space();
        awsRegionSelected = (AWSRegionSystemName)EditorGUILayout.EnumPopup("RegionEndpoint", awsRegionSelected);
        serializedObject.FindProperty("AWSRegion").stringValue = awsRegionSelected.ToString();
    }

    //When the categoryToDisplay enum is at "Magic"
    void DisplayLocalInfo()
    {
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("FilePathToWriteLogsTo"));
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("UploadFileType"));
        EditorGUILayout.Space();
    }
}
#endif