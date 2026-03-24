using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hard‑coded output PNG file
        string outputPath = @"C:\Images\combined.png";

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

        // Load each JPG into an Image instance
        Image[] images = new Image[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            images[i] = Image.Load(inputPaths[i]);
        }

        // Create a multipage image from the loaded JPGs
        using (Image combined = Image.Create(images))
        {
            // Save the combined image as a single PNG file
            combined.Save(outputPath, new PngOptions());
        }

        // Dispose the individual images
        foreach (var img in images)
        {
            img.Dispose();
        }
    }
}