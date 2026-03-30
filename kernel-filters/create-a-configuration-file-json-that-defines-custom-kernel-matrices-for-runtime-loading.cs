using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path for the JSON configuration file
        string outputPath = "output/kernels.json";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // JSON defining custom kernel matrices
        string json = @"{
  ""kernels"": [
    {
      ""name"": ""CustomEdgeDetect"",
      ""matrix"": [
        [ -1, -1, -1 ],
        [  0,  0,  0 ],
        [  1,  1,  1 ]
      ]
    },
    {
      ""name"": ""CustomSharpen"",
      ""matrix"": [
        [  0, -1,  0 ],
        [ -1,  5, -1 ],
        [  0, -1,  0 ]
      ]
    }
  ]
}";

        // Write the JSON to the file
        using (var writer = new StreamWriter(outputPath))
        {
            writer.Write(json);
        }
    }
}