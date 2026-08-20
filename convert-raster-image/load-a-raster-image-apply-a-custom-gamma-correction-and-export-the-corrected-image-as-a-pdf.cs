// HOW-TO: Apply Gamma Correction to PNG and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample_corrected.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterCachedImage to access AdjustGamma
                var rasterImage = (RasterCachedImage)image;

                // Apply gamma correction (same coefficient for all channels)
                rasterImage.AdjustGamma(2.2f);

                // Save the corrected image as PDF
                rasterImage.Save(outputPath, new PdfOptions());
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
 * 1. When you need to improve the brightness and contrast of a scanned PNG before embedding it in a PDF report.
 * 2. When you must convert a batch of product photos to PDF with consistent gamma for print‑ready output.
 * 3. When an application requires on‑the‑fly gamma adjustment of user‑uploaded images prior to generating a PDF invoice.
 * 4. When you are building a document generation service that normalizes image luminance before saving the final PDF.
 * 5. When you want to programmatically correct the gamma of a raster image and archive it as a searchable PDF using C#.
 */
