using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.psd";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options
                var pdfOptions = new PdfOptions();

                // Configure vector rasterization options for optimal quality
                var rasterOptions = new VectorRasterizationOptions
                {
                    // Use white background for the PDF page
                    BackgroundColor = Color.White,
                    // Match PDF page size to the source image dimensions
                    PageSize = new Size(image.Width, image.Height),
                    // High‑quality smoothing
                    SmoothingMode = SmoothingMode.AntiAlias,
                    // High‑quality text rendering
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as PDF with the configured options
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
 * 1. When a developer needs to convert layered Photoshop PSD files into printable PDF documents while preserving smooth edges and crisp text using Aspose.Imaging for .NET.
 * 2. When an application must generate PDF reports from design assets stored as PSD images, ensuring anti‑aliased graphics and text for professional‑grade visual quality.
 * 3. When a web service processes user‑uploaded PSD files and returns high‑resolution PDF previews with white backgrounds and page sizes that match the original image dimensions.
 * 4. When a batch‑processing tool archives marketing assets by converting multiple PSD files to PDF with consistent smoothing and text rendering settings to maintain brand consistency.
 * 5. When a desktop utility needs to export PSD artwork to PDF for legal or compliance documentation, requiring exact page size matching and anti‑aliasing to meet regulatory visual standards.
 */