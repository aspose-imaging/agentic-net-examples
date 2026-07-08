using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            // Verify that the EPS source file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = Image.Load(inputPath))
            {
                // Calculate double size based on original dimensions
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize using a high‑quality resampling method
                image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);

                // Save as a high‑resolution PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a vector EPS logo to a high‑resolution PNG for use on a retina display, they can double its size and export it with Aspose.Imaging.
 * 2. When preparing print‑ready artwork that must be scaled up from an EPS source before being embedded in a PDF, this code resizes the image and saves it as a lossless PNG.
 * 3. When a web application must generate zoomable product thumbnails from EPS files, the code doubles the dimensions and outputs a high‑quality PNG for smooth scaling.
 * 4. When migrating legacy EPS assets to a modern asset pipeline that only accepts PNG, developers can use this snippet to upscale and preserve detail during conversion.
 * 5. When an e‑learning platform requires high‑resolution PNG screenshots of EPS diagrams for offline viewing, the code resizes the vector and saves it with Aspose.Imaging’s high‑quality resampling.
 */