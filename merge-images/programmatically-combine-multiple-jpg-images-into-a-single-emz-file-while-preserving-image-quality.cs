using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
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

        // Hardcoded output EMZ file
        string outputPath = @"C:\Images\combined.emz";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the first image to obtain page size for the EMF rasterization options
        using (Image firstImage = Image.Load(inputFiles[0]))
        {
            // Configure rasterization options with the size of the first image
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = firstImage.Size
            };

            // Configure EMF options: enable compression and assign rasterization options
            EmfOptions emfOptions = new EmfOptions
            {
                Compress = true,
                VectorRasterizationOptions = rasterOptions
            };

            // Create a multipage image from the JPG files
            using (Image multiImage = Image.Create(inputFiles))
            {
                // Save the combined image as a compressed EMZ file
                multiImage.Save(outputPath, emfOptions);
            }
        }
    }
}