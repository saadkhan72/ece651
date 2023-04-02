using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
public class BuildScript : MonoBehaviour
{
    public static void PerformBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/Level 1.unity","Assets/Scenes/Level 2.unity","Assets/Scenes/Level 3.unity","Assets/Scenes/Level 4.unity","Assets/Scenes/Level 5.unity"};
        buildPlayerOptions.locationPathName = "./Builds/hamburgerx64.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.Development;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}

