// HOW-TO: Export EMF to PDF with Vector Shapes and Anti‑Alias Smoothing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.emf";
        string outputPath = "Output\\sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure vector rasterization options with smoothing and text rendering as shapes
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                };

                // Set up PDF export options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = vectorOptions;

                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to convert a Windows Metafile (EMF) containing text into a searchable PDF while preserving the text as scalable vector shapes.
 * 2. When you want to improve the visual quality of EMF graphics in a PDF by applying anti‑alias smoothing during rasterization.
 * 3. When generating PDF reports from legacy EMF assets and you require consistent background color and page dimensions matching the original image.
 * 4. When automating a batch process that validates EMF files exist, creates output folders, and exports them to PDF using Aspose.Imaging in a .NET application.
 * 5. When you must control text rendering hints for EMF‑to‑PDF conversion to ensure crisp, single‑bit per pixel text rendering in the final document.
 */
