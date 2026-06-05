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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.emf";
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
                // Prepare rasterization options (e.g., set page size to original image size)
                var rasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    // Example of quality-related settings
                    BackgroundColor = Color.White,
                    // You can adjust other properties such as TextRenderingHint, SmoothingMode, etc.
                };

                // Configure EMF save options
                var saveOptions = new EmfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    Compress = true // Enable compression for smaller file size
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
 * 1. When a C# application must convert a high‑resolution EMF diagram to a compressed EMF file while preserving the original page size and background color for faster transmission over a network.
 * 2. When a developer needs to batch‑process vector graphics in a Windows desktop tool and ensure each saved EMF file uses specific rasterization settings such as smoothing mode and text rendering hint to maintain visual fidelity.
 * 3. When generating printable reports that embed EMF charts, and the code must enforce compression and consistent page dimensions to keep the PDF file size low without losing quality.
 * 4. When integrating Aspose.Imaging into a document‑management system that validates incoming EMF files and re‑saves them with a white background to avoid transparency issues in downstream viewers.
 * 5. When an automated build pipeline must re‑encode source EMF assets with custom EmfOptions to guarantee that all output files meet a company‑wide standard for image compression and color handling.
 */