using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System;
using System.IO;

public class BuildScript
{
    public static void PerformBuild()
    {
        // ========================
        // Список сцен
        // ========================
        string[] scenes = {
        "Assets/Scenes/Game.unity",
        };

        // ========================
        // Пути к файлам сборки
        // ========================
        string aabPath = "ThreeChickens.aab";
        string apkPath = "ThreeChickens.apk";

        // ========================
        // Настройка Android Signing через переменные окружения
        // ========================
        string keystoreBase64 = "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";
        string keystorePass = "oldschool";
        string keyAlias = "threeone";
        string keyPass = "oldschool";

        string tempKeystorePath = null;

        if (!string.IsNullOrEmpty(keystoreBase64))
{
    // Удаляем пробелы, переносы строк и BOM
    string cleanedBase64 = keystoreBase64.Trim()
                                         .Replace("\r", "")
                                         .Replace("\n", "")
                                         .Trim('\uFEFF');

    // Создаем временный файл keystore
    tempKeystorePath = Path.Combine(Path.GetTempPath(), "TempKeystore.jks");
    File.WriteAllBytes(tempKeystorePath, Convert.FromBase64String(cleanedBase64));

    PlayerSettings.Android.useCustomKeystore = true;
    PlayerSettings.Android.keystoreName = tempKeystorePath;
    PlayerSettings.Android.keystorePass = keystorePass;
    PlayerSettings.Android.keyaliasName = keyAlias;
    PlayerSettings.Android.keyaliasPass = keyPass;

    Debug.Log("Android signing configured from Base64 keystore.");
}
        else
        {
            Debug.LogWarning("Keystore Base64 not set. APK/AAB will be unsigned.");
        }

        // ========================
        // Общие параметры сборки
        // ========================
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // ========================
        // 1. Сборка AAB
        // ========================
        EditorUserBuildSettings.buildAppBundle = true;
        options.locationPathName = aabPath;

        Debug.Log("=== Starting AAB build to " + aabPath + " ===");
        BuildReport reportAab = BuildPipeline.BuildPlayer(options);
        if (reportAab.summary.result == BuildResult.Succeeded)
            Debug.Log("AAB build succeeded! File: " + aabPath);
        else
            Debug.LogError("AAB build failed!");

        // ========================
        // 2. Сборка APK
        // ========================
        EditorUserBuildSettings.buildAppBundle = false;
        options.locationPathName = apkPath;

        Debug.Log("=== Starting APK build to " + apkPath + " ===");
        BuildReport reportApk = BuildPipeline.BuildPlayer(options);
        if (reportApk.summary.result == BuildResult.Succeeded)
            Debug.Log("APK build succeeded! File: " + apkPath);
        else
            Debug.LogError("APK build failed!");

        Debug.Log("=== Build script finished ===");

        // ========================
        // Удаление временного keystore
        // ========================
        if (!string.IsNullOrEmpty(tempKeystorePath) && File.Exists(tempKeystorePath))
        {
            File.Delete(tempKeystorePath);
            Debug.Log("Temporary keystore deleted.");
        }
    }
}
