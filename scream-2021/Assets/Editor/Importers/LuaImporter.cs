﻿using UnityEngine;
using UnityEditor.Experimental.AssetImporters;
using System.IO;
using MoonSharp.Interpreter;
using System;

[ScriptedImporter(1, new string[] { "scene", "lua" })]
public class LuaImporter : ScriptedImporter {

    public override void OnImportAsset(AssetImportContext context) {
        var script = ScriptableObject.CreateInstance<LuaSerializedScript>();
        var text = File.ReadAllText(context.assetPath);
        script.luaString = text;
        context.AddObjectToAsset("Script", script);
        context.SetMainObject(script);

        var testScript = new Script();
        try {
            testScript.LoadString(text);
        } catch (Exception e) {
            Debug.LogError("Script doesn't compile: " + context.assetPath + "\n\n" + e);
        }
    }
}
