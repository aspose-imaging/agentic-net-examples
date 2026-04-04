using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Dithering;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.psd";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply dithering
            RasterImage raster = image as RasterImage;
            if (raster != null)
            {
                // Apply Floyd‑Steinberg dithering with an 8‑bit palette
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Set smoothing mode if the property is available
                // raster.SmoothingMode = SmoothingMode.AntiAlias; // Uncomment if supported
            }

            // Configure PDF export options
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the processed image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}