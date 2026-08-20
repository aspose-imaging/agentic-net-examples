// HOW-TO: Set Gamma of CDR to 0.8 and Export as TIFF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR document
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize CDR to a TIFF image in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    var rasterOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, rasterOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (TiffImage tiff = (TiffImage)Image.Load(ms))
                    {
                        // Apply gamma correction
                        tiff.AdjustGamma(0.8f);

                        // Save the corrected image as TIFF
                        tiff.Save(outputPath);
                    }
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
 * 1. When a developer needs to adjust the brightness of a CorelDRAW (CDR) illustration before converting it to a high‑resolution TIFF for printing.
 * 2. When an automated workflow must rasterize vector CDR files and apply gamma correction to match a specific color profile for archival storage.
 * 3. When a batch process converts multiple CDR designs to TIFF while ensuring consistent gamma values for downstream image analysis.
 * 4. When integrating Aspose.Imaging into a C# application that prepares CDR assets for publishing platforms that only accept TIFF images with corrected gamma.
 * 5. When troubleshooting visual discrepancies by programmatically tweaking the gamma of a CDR‑derived image before saving it as TIFF.
 */
