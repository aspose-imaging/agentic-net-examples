using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input\\sample.eps";
            string outputPath = "output\\result.png";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = Image.Load(inputPath))
            {
                // Calculate double size based on original dimensions
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize using a high‑quality interpolation method
                image.Resize(newWidth, newHeight, ResizeType.Mitchell);

                // Save the resized image as a high‑resolution PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a graphic designer needs to convert a vector EPS logo to a high‑resolution PNG for web display and wants to double its size programmatically using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform must generate larger product thumbnails from EPS source files to meet retina‑ready display requirements, resizing them with high‑quality interpolation and saving as PNG.
 * 3. When a publishing workflow requires batch conversion of EPS illustrations to double‑sized PNG images for print‑ready PDFs, using Aspose.Imaging’s Resize method in a .NET application.
 * 4. When a GIS application imports EPS map symbols and needs to upscale them to twice their original dimensions for detailed overlay, exporting the result as a lossless PNG via C# code.
 * 5. When a marketing automation script has to prepare double‑resolution PNG assets from EPS artwork for social‑media ads, ensuring the images are resized with Mitchell interpolation for optimal visual quality.
 */