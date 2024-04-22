#if UNITY_EDITOR

using System.IO;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class TMPHelper : MonoBehaviour
{

    void Start()
    {
        if (Application.IsPlaying(gameObject))
        {
            // Play logic
        }
        else
        {
            string assetsPath = Application.dataPath;
            bool folderExists = CheckFolderRecursive(assetsPath, "TextMesh Pro");

            if (folderExists)
            {
                Debug.Log("TMPRO is already imported");
            }
            else
            {
                TMP_PackageUtilities.ImportProjectResourcesMenu();
            }
        }
    }

    private static bool CheckFolderRecursive(string directoryPath, string folderName)
    {
        string[] subDirectories = Directory.GetDirectories(directoryPath);

        foreach (string subDirectory in subDirectories)
        {
            if (Path.GetFileName(subDirectory) == folderName)
            {
                return true;
            }

            bool folderExists = CheckFolderRecursive(subDirectory, folderName);

            if (folderExists)
            {
                return true;
            }
        }

        return false;
    }


}//Class

#endif