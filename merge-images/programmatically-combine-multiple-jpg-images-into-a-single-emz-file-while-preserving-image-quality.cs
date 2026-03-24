using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputFiles = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hard‑coded output EMZ file
        string outputPath = @"C:\Output\combined.emz";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files
        using (Image multipageImage = Image.Create(inputFiles))
        {
            // Set EMF options with compression to produce EMZ
            EmfOptions emfOptions = new EmfOptions
            {
                Compress = true
            };

            // Save the combined image as EMZ
            multipageImage.Save(outputPath, emfOptions);
        }
    }
}