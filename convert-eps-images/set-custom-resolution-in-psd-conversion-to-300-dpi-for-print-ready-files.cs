// HOW-TO: Set PSD resolution to 300 DPI in C# using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output file paths (relative to the executable directory)
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/output.psd";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options with 300 DPI resolution
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    psdOptions.ResolutionSettings = new ResolutionSetting(300.0, 300.0);
                    // Save the image as PSD with the specified options
                    image.Save(outputPath, psdOptions);
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
 * 1. When you need to convert a JPEG photo to a PSD file that meets print‑ready 300 DPI specifications for a magazine layout.
 * 2. When an e‑commerce platform must generate high‑resolution PSD assets from user‑uploaded images for offline catalog printing.
 * 3. When a graphic‑design workflow requires batch processing of images to PSD while enforcing a consistent 300 DPI resolution for professional printing.
 * 4. When a marketing automation script creates PSD mockups from web images and must ensure the output meets standard print resolution standards.
 * 5. When a document‑generation service converts web‑optimized JPEGs to PSDs and needs to embed 300 DPI metadata so printers do not upscale the artwork.
 */
