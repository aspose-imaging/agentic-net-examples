using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input CMX file paths
        string[] inputPaths = new string[]
        {
            @"C:\temp\input1.cmx",
            @"C:\temp\input2.cmx",
            @"C:\temp\input3.cmx"
        };

        // Hardcoded output CMX file path
        string outputPath = @"C:\temp\merged.cmx";

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the CMX files (preserves layer order)
        using (Image merged = Image.Create(inputPaths))
        {
            // Save the merged CMX drawing
            merged.Save(outputPath);
        }
    }
}