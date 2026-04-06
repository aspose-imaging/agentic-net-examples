using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Hardcoded output PNG file
        string outputPath = @"C:\Images\combined_output.png";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image (PSD internally) from the JPG files
        // Using the overload that accepts an array of file paths
        using (Image multiImage = Image.Create(inputPaths))
        {
            // Save the combined image as a single PNG (layers are flattened)
            multiImage.Save(outputPath, new PngOptions());
        }
    }
}