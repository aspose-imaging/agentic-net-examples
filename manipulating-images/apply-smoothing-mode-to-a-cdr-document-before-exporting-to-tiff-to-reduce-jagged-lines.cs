using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\Images\\sample.cdr";
            string outputPath = "C:\\Images\\sample.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with smoothing (anti-aliasing)
                var rasterOptions = new CdrRasterizationOptions
                {
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    PageSize = image.Size
                };

                // Set up TIFF save options and attach rasterization options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When converting CorelDRAW (CDR) vector artwork to high‑resolution TIFF files for printing, a developer can apply anti‑alias smoothing to eliminate jagged edges.
 * 2. When a .NET application needs to generate archival TIFF images from CDR designs while preserving line quality, the code sets SmoothingMode to AntiAlias during rasterization.
 * 3. When integrating Aspose.Imaging into a document‑management system that ingests CDR files and outputs TIFF for downstream OCR processing, smoothing ensures clearer text and graphics.
 * 4. When automating batch conversion of CDR logos to TIFF for web publishing, developers use this code to apply anti‑aliasing so the logos appear crisp on high‑DPI screens.
 * 5. When building a C# utility that validates CDR drawings by exporting them to TIFF for visual inspection, the smoothing mode helps reveal subtle design details without pixelation.
 */