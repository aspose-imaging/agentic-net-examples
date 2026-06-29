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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\output.emf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options (quality settings)
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.White,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                // Configure EMF save options
                var saveOptions = new EmfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Compress = true // enable compression for smaller output
                };

                // Save the image with the specified options
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
 * 1. When a C# application must convert high‑resolution vector drawings stored as EMF files into compressed EMF files for faster download in a web portal.
 * 2. When a reporting tool generates charts as EMF and needs to ensure consistent background color and text rendering before embedding the image in PDF reports.
 * 3. When a batch‑processing service processes scanned documents, rasterizes them with specific smoothing and page size settings, and saves them as optimized EMF for archival.
 * 4. When a desktop publishing software needs to preserve vector fidelity while reducing file size by enabling compression and controlling rasterization options for printed brochures.
 * 5. When an automated workflow validates that an input EMF exists, creates the output directory, and saves the image with custom rasterization parameters to meet corporate branding guidelines.
 */