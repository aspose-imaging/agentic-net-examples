using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.jpg";
        string outputPath = "Output/sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image and save it as PNG
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            image.Save(outputPath, new PngOptions());
        }

        // Simple verification that the PNG file was created
        if (File.Exists(outputPath))
        {
            Console.WriteLine($"PNG file saved successfully: {outputPath}");
        }
        else
        {
            Console.Error.WriteLine($"Failed to save PNG file: {outputPath}");
        }
    }
}