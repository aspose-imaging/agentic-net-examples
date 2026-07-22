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
            // Define input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Configure PNG options with maximum compression
                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.CompressionLevel = 9; // Max compression

                    // Set vector rasterization options to match the source size
                    pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    };

                    // Save as PNG
                    cdr.Save(outputPath, pngOptions);
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
 * 1. When a graphic designer needs to archive CorelDRAW (CDR) artwork as the smallest possible PNG files for web delivery, a developer can use this code to convert and apply maximum compression.
 * 2. When an e‑commerce platform must generate lightweight product thumbnails from CDR source files to improve page load speed, the code provides C# conversion with high‑compression PNG output.
 * 3. When a document management system automatically extracts vector drawings from CDR files and stores them as lossless PNGs with minimal storage footprint, this snippet handles the conversion and sets the compression level to 9.
 * 4. When a batch processing job needs to convert a large library of CorelDRAW drawings to PNG while preserving exact dimensions and applying maximum compression to reduce cloud storage costs, the example demonstrates the required Aspose.Imaging C# workflow.
 * 5. When a mobile app backend must serve PNG previews of CDR designs with the smallest possible file size to conserve bandwidth, developers can employ this code to rasterize the vector image and enforce the highest PNG compression.
 */