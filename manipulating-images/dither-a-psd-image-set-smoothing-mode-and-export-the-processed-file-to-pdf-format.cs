// HOW-TO: How To Dither A PSD And Save As PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input PSD file and output PDF file (relative paths)
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/processed.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for dithering
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                raster.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1);

                // Prepare PDF export options with smoothing mode set
                var pdfOptions = new PdfOptions();
                var vecOptions = new VectorRasterizationOptions
                {
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };
                pdfOptions.VectorRasterizationOptions = vecOptions;

                // Save the processed image as PDF
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
 * 1. When you need to convert a high‑resolution Photoshop PSD into a compact black‑and‑white PDF for printing or archiving.
 * 2. When you want to apply Floyd‑Steinberg dithering to reduce colors to a 1‑bit palette before embedding the image in a PDF report.
 * 3. When you must ensure the PDF export uses no smoothing to preserve the sharp edges of a dithered bitmap.
 * 4. When you are automating a batch process that validates the PSD file exists, creates output folders, and generates PDF files programmatically in a .NET application.
 * 5. When you need to cache raster data of a large PSD to avoid memory issues while performing image processing and saving the result as PDF.
 */
