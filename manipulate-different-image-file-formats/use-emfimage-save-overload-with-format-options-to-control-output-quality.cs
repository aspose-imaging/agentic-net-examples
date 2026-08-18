// HOW-TO: How To Save EMF With Compression Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Input\sample.emf";
        string outputPath = @"C:\Output\sample_output.emf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (EMF or any supported format)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options matching the source image size
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure EMF save options (e.g., enable compression)
                var emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Compress = true // control output quality by compressing the EMF
                };

                // Save the image using the EMF options
                image.Save(outputPath, emfOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the file size of vector‑based EMF drawings before storing them in a database or sending them over a network.
 * 2. When you must generate EMF reports from a C# application and want to enable compression to keep the documents lightweight.
 * 3. When you are converting legacy EMF assets to a compressed format to meet storage quotas in an enterprise document management system.
 * 4. When you want to programmatically rasterize an EMF to match its original dimensions while preserving vector quality and applying compression.
 * 5. When you are building an automated pipeline that validates the existence of source files, creates output folders, and saves compressed EMF files using Aspose.Imaging.
 */
