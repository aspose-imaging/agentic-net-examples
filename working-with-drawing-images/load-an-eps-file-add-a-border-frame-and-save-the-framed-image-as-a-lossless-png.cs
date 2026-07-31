using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output.png";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure rasterization options to add a border frame
                var rasterOptions = new EpsRasterizationOptions
                {
                    // Border size in pixels (adjust as needed)
                    BorderX = 10,
                    BorderY = 10,
                    // Preserve original dimensions
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };

                // Set up PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the framed image as a lossless PNG
                epsImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a print‑shop automation tool built with Aspose.Imaging for .NET needs to convert vector EPS artwork into a web‑ready PNG thumbnail with a uniform margin for preview pages.
 * 2. When an e‑commerce platform using C# and Aspose.Imaging must generate product images from supplier EPS logos, adding a consistent frame before storing them as lossless PNG files for high‑quality display.
 * 3. When a document‑management system written in C# imports EPS diagrams, adds a border via Aspose.Imaging rasterization options, and creates PNG snapshots for inclusion in reports.
 * 4. When a desktop publishing application built on Aspose.Imaging for .NET offers users the ability to export their EPS designs as PNG assets with a customizable border for presentations.
 * 5. When a batch‑processing script in C# processes archival EPS files, applies a safety margin using Aspose.Imaging’s EpsRasterizationOptions, and saves them as lossless PNG to ensure browser compatibility.
 */