using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR vector image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Configure PNG options for lossless compression
                PngOptions pngOptions = new PngOptions
                {
                    // Maximum compression (still lossless)
                    CompressionLevel = 9,
                    // Preserve original metadata
                    KeepMetadata = true,
                    // Rasterize using original dimensions
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                // Save the rasterized PNG
                cdr.Save(outputPath, pngOptions);
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
 * 1. When a graphic designer needs to archive CorelDRAW (.cdr) artwork as losslessly compressed PNG files for web publishing without altering the original size, they can use this C# Aspose.Imaging code.
 * 2. When a print shop must convert client‑provided CDR logos to PNG thumbnails for proofing while preserving exact dimensions and metadata, the example demonstrates the required steps.
 * 3. When a document management system automatically processes incoming CDR files and stores them as high‑quality PNG images for searchable archives, this code provides the lossless conversion routine.
 * 4. When a software vendor integrates batch image conversion into a .NET application to generate PNG assets from CDR source files without quality loss, the snippet shows how to configure compression level and rasterization options.
 * 5. When a developer builds a CI/CD pipeline that validates visual assets by converting CDR designs to PNG and comparing pixel‑perfect results, the example ensures the PNG output matches the original dimensions and retains metadata.
 */