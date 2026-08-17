// HOW-TO: Batch Convert EMF Files to PNG with White Background in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputEmf";
            string outputDirectory = @"C:\OutputPng";

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options with a uniform background color
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageSize = image.Size
                    };

                    // Set PNG save options and attach the rasterization options
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the image as PNG
                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to generate web‑ready PNG thumbnails from a collection of EMF vector drawings and ensure a consistent white background.
 * 2. When automating the migration of legacy Windows Metafile assets to a format supported by modern browsers without losing visual fidelity.
 * 3. When preparing print‑ready images from EMF diagrams for inclusion in PDF reports that require a raster background.
 * 4. When building a batch processing tool that standardizes background colors across dozens of EMF logos before uploading them to a content management system.
 * 5. When converting EMF icons stored on a server to PNG for use in a cross‑platform C# application that cannot render vector formats directly.
 */
