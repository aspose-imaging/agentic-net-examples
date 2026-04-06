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
            @"C:\temp\image1.jpg",
            @"C:\temp\image2.jpg",
            @"C:\temp\image3.jpg"
        };

        // Hard‑coded output PNG file
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

        // Create a multipage image from the JPG files (DJVU processing is implicit via Aspose.Imaging)
        using (Image multiImage = Image.Create(inputPaths))
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the combined image as a single PNG file
            multiImage.Save(outputPath, new PngOptions());
        }
    }
}