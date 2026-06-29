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

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path with .png extension
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up rasterization options with a uniform background color
                    var rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.LightGray,
                        PageSize = image.Size
                    };

                    // Set up PNG save options
                    var pngOptions = new PngOptions
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
 * 1. When a developer must generate web‑ready PNG thumbnails from a folder of Windows Metafile (EMF) diagrams while ensuring a consistent light‑gray background for all images.
 * 2. When an automated build process needs to convert a batch of vector‑based EMF icons to raster PNG assets for inclusion in a cross‑platform mobile app.
 * 3. When a reporting tool exports charts as EMF files and the developer wants to batch‑convert them to PNG with a uniform background color for embedding in PDF documents.
 * 4. When a legacy CAD system outputs technical drawings in EMF format and the developer needs to produce PNG previews for a cloud‑based viewer that requires a solid background.
 * 5. When a content management workflow requires periodic conversion of EMF logos stored in a directory to PNG files with a predefined background to maintain visual consistency across a website.
 */