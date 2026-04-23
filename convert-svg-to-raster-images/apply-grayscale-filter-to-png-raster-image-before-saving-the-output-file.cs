using System;
using System.IO;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.grayscale.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image, convert it to grayscale, and save the result
        using (PngImage pngImage = new PngImage(inputPath))
        {
            pngImage.Grayscale();
            pngImage.Save(outputPath);
        }
    }
}