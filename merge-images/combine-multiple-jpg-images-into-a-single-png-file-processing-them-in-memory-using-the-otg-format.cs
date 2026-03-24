using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hard‑coded output PNG file
        string outputPath = @"C:\Images\combined_output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files (OTG processing is handled internally)
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the combined image as a single PNG file
            multipageImage.Save(outputPath, pngOptions);
        }
    }
}