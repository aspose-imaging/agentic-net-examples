using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG file paths
        string[] inputPaths = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hardcoded output AVIF file path
        string outputPath = @"C:\Images\combined.avif";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files
        // This uses the built‑in Image.Create(string[]) method (lifecycle rule)
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Save the combined image as AVIF.
            // The Save method will infer the format from the file extension.
            multipageImage.Save(outputPath);
        }
    }
}