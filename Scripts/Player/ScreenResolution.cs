using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
	Class makes sure the game resolution fits the screen resolutioni
*/
public class ScreenResolution : MonoBehaviour {

	/*
		Retrieves the desired screen resolution from an external file and
		fits the game to this resolution
	*/
	void Awake () {
        string line = readResolution();
        string[] parts = line.Split(',');

        Screen.SetResolution(int.Parse(parts[0]), int.Parse(parts[1]), true);
	}

	/*
		Reads the Resolution.txt file in the data folder
		return : string representing the desired resolution
	*/
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
