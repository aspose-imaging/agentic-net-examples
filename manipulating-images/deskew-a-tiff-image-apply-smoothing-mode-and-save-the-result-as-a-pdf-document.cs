// HOW-TO: Deskew TIFF Image and Save as PDF with Anti-Aliasing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
        {
            outputDir = Directory.GetCurrentDirectory();
        }
        Directory.CreateDirectory(outputDir);

        try
        {
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Deskew the image (normalize angle)
                if (image is RasterImage rasterImage)
                {
                    rasterImage.NormalizeAngle(false, Color.LightGray);
                }
                else if (image is TiffImage tiffImage)
                {
                    tiffImage.NormalizeAngle(false, Color.LightGray);
                }

                // Prepare PDF save options with smoothing mode
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias,
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                // Save the result as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When scanning documents that are slightly rotated, a developer can deskew the TIFF and convert it to a clean PDF for archiving.
 * 2. When generating printable PDFs from high‑resolution TIFF scans, applying anti‑alias smoothing ensures smooth edges and better visual quality.
 * 3. When integrating Aspose.Imaging into a C# workflow to batch‑process scanned forms, this code normalizes angles and outputs PDF files ready for downstream systems.
 * 4. When a web service receives uploaded TIFF images and needs to return a PDF with consistent page dimensions and white background, the example provides the needed conversion steps.
 * 5. When creating a document management solution that stores original TIFFs but serves users PDF versions, the code handles deskewing and smoothing automatically in .NET.
 */
