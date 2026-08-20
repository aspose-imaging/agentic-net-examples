// HOW-TO: Convert PSD to PDF with Anti-Aliasing Smoothing and Text Rendering in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
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
                // Configure PDF options with vector rasterization settings for optimal quality
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    }
                };

                // Save as PDF
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
 * 1. When you need to generate a high‑quality PDF from a Photoshop PSD file while preserving smooth edges and clear text in a .NET application.
 * 2. When you are building an automated report system that converts layered PSD designs into printable PDFs with anti‑aliased graphics.
 * 3. When you must ensure that exported PDFs retain the original PSD dimensions and white background for consistent layout across devices.
 * 4. When you want to programmatically control vector rasterization settings such as page size, smoothing mode, and text rendering hint during image format conversion.
 * 5. When you are integrating Aspose.Imaging into a C# service that validates input files, creates output folders, and saves PDFs with optimal visual fidelity.
 */
