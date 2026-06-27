using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.pdf";

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

            // Load the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Prepare PDF save options with anti-aliasing
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias
                    }
                };

                // Save the image as PDF
                tiffImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert a high‑resolution TIFF scan of architectural drawings into a PDF and wants smooth vector edges for professional printing, they set SmoothingMode.AntiAlias before saving.
 * 2. When a medical imaging application must export DICOM‑derived TIFF images to PDF reports with clear, anti‑aliased contours for accurate diagnosis review, this code ensures the rendering quality.
 * 3. When a document management system processes scanned TIFF invoices and generates PDF files that must display crisp text and graphics on screen, applying anti‑aliasing prevents jagged edges.
 * 4. When a GIS tool transforms large geospatial TIFF raster layers into PDF maps and requires smooth boundary lines for better visual analysis, the smoothing mode is enabled during rasterization.
 * 5. When a publishing workflow converts multi‑page TIFF artwork into PDF brochures and needs the final PDF to retain smooth curves and fine details for digital distribution, the code sets the anti‑aliasing option before saving.
 */