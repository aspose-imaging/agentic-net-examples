using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path to the PNG file in the templates folder
        string inputPath = @"C:\Templates\image.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output path preserves the original filename
        string outputPath = inputPath;

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image, apply a filter, and save it back
        using (PngImage png = new PngImage(inputPath))
        {
            // Example filter: convert the image to grayscale
            png.Grayscale();

            // Save the modified image to the original location
            png.Save(outputPath);
        }
    }
}