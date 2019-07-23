using UnityEngine;
using PolyToolkit;

public class LoadNewAsset : MonoBehaviour
{

    void Start()
    {
        PolyToolkit.PolyApi.GetAsset("assets/6LSB0OZK8I7", // ← id
        result => {
            PolyApi.Import(result.Value, PolyImportOptions.Default());
        });
    }
}