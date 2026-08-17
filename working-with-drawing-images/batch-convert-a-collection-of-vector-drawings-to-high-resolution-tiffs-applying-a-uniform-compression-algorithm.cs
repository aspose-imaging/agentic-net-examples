// HOW-TO: Batch Convert SVG EMF CDR to High‑Resolution LZW TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded collection of vector input files
            var inputFiles = new List<string>
            {
                @"C:\VectorImages\drawing1.svg",
                @"C:\VectorImages\drawing2.emf",
                @"C:\VectorImages\drawing3.cdr"
            };

            // Corresponding output TIFF files (same folder, .tif extension)
            var outputFiles = new List<string>
            {
                @"C:\ConvertedTiffs\drawing1.tif",
                @"C:\ConvertedTiffs\drawing2.tif",
                @"C:\ConvertedTiffs\drawing3.tif"
            };

            for (int i = 0; i < inputFiles.Count; i++)
            {
                string inputPath = inputFiles[i];
                string outputPath = outputFiles[i];

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the vector image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare TIFF save options with uniform compression (LZW)
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.Lzw,
                        // High‑resolution rasterization settings
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            // Define a large page size for high resolution (e.g., 3000x3000 pixels)
                            PageSize = new Size(3000, 3000),
                            // Optional: improve quality
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        }
                    };

                    // Save as TIFF
                    image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to archive a set of design files (SVG, EMF, CDR) as lossless, high‑resolution TIFFs for printing or long‑term storage while reducing file size with LZW compression.
 * 2. When a document‑management system must automatically convert incoming vector drawings to TIFFs so they can be displayed in web viewers that only support raster images.
 * 3. When a batch processing pipeline has to generate printable TIFFs from vector assets for a publishing workflow, ensuring consistent resolution and compression across all pages.
 * 4. When a GIS or CAD integration requires converting multiple vector map layers into a single TIFF format for compatibility with legacy analysis tools.
 * 5. When a cloud service needs to pre‑process user‑uploaded vector graphics into compressed TIFF thumbnails for fast preview generation without losing detail.
 */
