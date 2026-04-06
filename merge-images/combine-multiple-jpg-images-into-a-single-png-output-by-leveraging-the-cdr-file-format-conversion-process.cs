using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
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

        // Hardcoded output PNG file
        string outputPath = @"C:\Images\combined.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the multipage image as a single PNG.
            // Aspose.Imaging rasterizes all pages into one image.
            multipageImage.Save(outputPath, pngOptions);
        }
    }
}