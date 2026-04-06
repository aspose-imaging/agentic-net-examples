using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hardcoded output OTG file
        string outputPath = @"C:\Images\combined.otg";

        // Validate each input file
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Load each JPG image
        List<Image> loadedImages = new List<Image>();
        foreach (string inputPath in inputPaths)
        {
            Image img = Image.Load(inputPath); // uses Image.Load rule
            loadedImages.Add(img);
        }

        // Combine loaded images into a multipage image
        Image multipageImage = Image.Create(loadedImages.ToArray()); // uses Image.Create(Image[]) rule

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Save the combined image as OTG
        multipageImage.Save(outputPath); // format inferred from .otg extension

        // Clean up resources
        multipageImage.Dispose();
        foreach (var img in loadedImages)
        {
            img.Dispose();
        }
    }
}