// HOW-TO: Crop EMF Image to Specific Area and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Define crop rectangle (x, y, width, height)
                int cropX = 50;
                int cropY = 50;
                int cropWidth = 200;
                int cropHeight = 150;
                Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Perform cropping
                emfImage.Crop(cropRect);

                // Save the cropped image as PNG
                PngOptions pngOptions = new PngOptions();
                emfImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a portion of a vector‑based EMF diagram and deliver it as a lightweight PNG for web display.
 * 2. When an automated report generator creates EMF charts that must be trimmed to focus on a specific region before embedding in a PDF.
 * 3. When a desktop application imports legacy EMF icons and must crop them to uniform dimensions for use in a modern UI as PNG assets.
 * 4. When a batch processing script has to convert multiple EMF files to PNG while removing unwanted margins by specifying integer crop coordinates.
 * 5. When a GIS tool exports map overlays in EMF format and you need to isolate a city block area and save it as a PNG thumbnail.
 */
