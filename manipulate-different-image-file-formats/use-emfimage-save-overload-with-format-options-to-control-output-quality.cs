using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample_converted.emf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options (e.g., page size)
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set EMF save options, enabling compression for better quality/size trade‑off
                var saveOptions = new EmfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Compress = true
                };

                // Save the image using the specified options
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert an existing EMF file to a new EMF with compression enabled to reduce file size while preserving vector quality for inclusion in a PDF report.
 * 2. When a developer wants to ensure that an EMF image is rasterized to match its original dimensions before saving, useful for generating thumbnails that retain exact layout.
 * 3. When a developer must programmatically validate the existence of source EMF files and create output directories before performing batch processing of corporate branding assets.
 * 4. When a developer is integrating Aspose.Imaging into a C# application to export user‑drawn diagrams as compressed EMF files for faster web transmission.
 * 5. When a developer needs to handle exceptions gracefully while loading and saving EMF images with custom EmfOptions to maintain stability in an automated document generation pipeline.
 */