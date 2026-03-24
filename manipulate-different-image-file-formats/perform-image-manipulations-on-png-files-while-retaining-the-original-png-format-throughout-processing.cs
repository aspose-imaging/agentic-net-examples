using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image, apply grayscale, and save it back as PNG
        using (PngImage pngImage = new PngImage(inputPath))
        {
            // Convert the image to grayscale
            pngImage.Grayscale();

            // Save the processed image preserving PNG format
            pngImage.Save(outputPath);
        }
    }
}