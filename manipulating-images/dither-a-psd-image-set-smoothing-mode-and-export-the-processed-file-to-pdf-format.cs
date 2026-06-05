using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/processed.pdf";

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
                // Cast to raster image for dithering
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Apply Floyd‑Steinberg dithering with 8‑bit palette
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Configure PDF export options with smoothing mode
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = raster.Width,
                        PageHeight = raster.Height,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save the processed image as PDF
                raster.Save(outputPath, pdfOptions);
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
 * 1. When converting high‑resolution Photoshop PSD files to lightweight PDF documents for email distribution while preserving visual fidelity using Floyd‑Steinberg dithering.
 * 2. When generating printable PDFs from layered PSD artwork in a C# application and needing to control smoothing to avoid unwanted anti‑aliasing artifacts.
 * 3. When automating a batch process that prepares PSD designs for archival by reducing color depth with 8‑bit dithering and saving them as PDF for long‑term storage.
 * 4. When building a web service that receives PSD uploads, applies dithering to match a limited‑color printer palette, and returns a PDF with exact page dimensions.
 * 5. When creating a desktop utility that validates PSD files, applies a specific smoothing mode, and exports the result to PDF for inclusion in corporate reports.
 */