using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;


[InitializeOnLoad]
[ExecuteInEditMode]
class BundleVersion : AssetPostprocessor
{
	static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath)
	{
		Debug.Log ("Create version scripts");

		string path = @"./Assets/BundleVersion.cs";

		// Create a file to write to. 
		using (StreamWriter sw = File.CreateText(path))
		{
			sw.WriteLine("class BundleVersion {");
			sw.WriteLine(string.Format("  public static readonly string version = \"{0}\";", PlayerSettings.bundleVersion));
			sw.WriteLine ("}");
		}
	}

}