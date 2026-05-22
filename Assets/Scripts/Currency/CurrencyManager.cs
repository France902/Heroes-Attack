using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CurrencyManager : MonoBehaviour
{
    private int gold = 0;
    private int gems = 0;

    private string filePath;
    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "resources.csv");

        if (File.Exists(filePath))
        {
            LoadResourcesFromCSV();
        }
        else
        {
            CreateNewCSV();
        }
    }

    public void addCurrency(string type, int value)
    {
        switch(type)
        {
            case "gold":
                gold += value; break;
            case "gems":
                gems += value; break;
        }

        SaveResourcesToCSV();
    }

    private void CreateNewCSV()
    {
        gold = 0;
        gems = 0;

        string[] lines = {
            "gold,0",
            "gems,0"
        };

        File.WriteAllLines(filePath, lines);
        Debug.Log("file creato");
    }

    private void LoadResourcesFromCSV()
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');

                if (parts.Length == 2)
                {
                    string key = parts[0].Trim().ToLower();
                    int value = int.Parse(parts[1].Trim());

                    if (key == "gold") gold = value;
                    else if (key == "gems") gems = value;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Errore durante la lettura del CSV: " + e.Message);
            CreateNewCSV();
        }
    }

    private void SaveResourcesToCSV()
    {
        string[] lines = {
            $"gold,{gold}",
            $"gems,{gems}"
        };

        File.WriteAllLines(filePath, lines);
    }
}
