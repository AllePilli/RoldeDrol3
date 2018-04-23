using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenResolution : MonoBehaviour {

	void Awake () {
        string line = readResolution();
        string[] parts = line.Split(',');

        Screen.SetResolution(int.Parse(parts[0]), int.Parse(parts[1]), true);
	}

    private string readResolution()
    {
        try
        {
            StreamReader reader = new StreamReader(Application.dataPath + "/Resolution.txt");
            string line = reader.ReadToEnd();
            reader.Close();
            return line;
        }
        catch
        {
            string line = "1280,768";
            return line;
        }
    }
}
