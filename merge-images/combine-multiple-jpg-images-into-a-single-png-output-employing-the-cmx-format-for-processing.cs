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
            @"C:\temp\image1.jpg",
            @"C:\temp\image2.jpg",
            @"C:\temp\image3.jpg"
        };

        // Hardcoded output PNG file
        string outputPath = @"C:\temp\combined.png";

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

        // Load each JPG image
        Image[] images = new Image[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            images[i] = Image.Load(inputPaths[i]);
        }

        // Create a multipage image from the loaded JPGs (disposeImages = true)
        using (Image multipage = Image.Create(images, true))
        {
            // Save the combined image as a single PNG file
            multipage.Save(outputPath, new PngOptions());
        }
    }
}