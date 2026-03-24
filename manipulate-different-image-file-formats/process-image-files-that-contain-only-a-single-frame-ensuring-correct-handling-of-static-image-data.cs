using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Verify that the file can be loaded as an image
        if (!Image.CanLoad(inputPath))
        {
            Console.Error.WriteLine($"Cannot load image: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, process it as a static (single‑frame) image, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // If the image is a raster image, apply a simple processing step (e.g., convert to grayscale)
            if (image is RasterImage raster)
            {
                raster.Grayscale(); // static image processing
            }

            // Save the processed image to the output path
            image.Save(outputPath);
        }
    }
}