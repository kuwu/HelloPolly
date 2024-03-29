﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyToolkit;
using UnityEngine.UI;

public class LoadNewAssets : MonoBehaviour
{

    public int assetCount = 0;
    public Text attributionsText;

    void Start()
    {
        // Create a new request
        PolyListAssetsRequest req = new PolyListAssetsRequest();
        // Search by keywords    
        req.keywords = "frosted donut";
        // Make the request with a callback function
        PolyApi.ListAssets(req, GetDonuts);
    }

    private void GetDonuts(PolyStatusOr<PolyListAssetsResult> result)
    {
        // Set options for import so the assets aren't crazy sizes
        PolyImportOptions options = PolyImportOptions.Default();
        options.rescalingMode = PolyImportOptions.RescalingMode.FIT;
        options.desiredSize = 2.0f;
        options.recenter = true;
        // List our assets
        List<PolyAsset> assetsInUse = new List<PolyAsset>();
        // Loop through the list and display the first 3
        for (int i = 0; i < Mathf.Min(3, result.Value.assets.Count); i++)
        {
            // Import our assets into the scene with the ImportDonuts function
            PolyApi.Import(result.Value.assets[i], options, ImportDonuts);
            assetsInUse.Add(result.Value.assets[i]);

            // Attributions Text
            // attributionsText.text = PolyApi.GenerateAttributions(includeStatic: false, runtimeAssets: assetsInUse);
        }

    }

    private void ImportDonuts(PolyAsset asset, PolyStatusOr<PolyImportResult> result)
    {
        assetCount++;
        // Line the assets up so they don't overlap
        result.Value.gameObject.transform.position = new Vector3(assetCount * 2.5f, 0f, 0f);
    }
}