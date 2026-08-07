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
            string inputPath = @"C:\Images\input.psd";
            string outputPath = @"C:\Images\output.pdf";

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
                // Cast to RasterImage to access Dither method
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                // Perform ordered (threshold) dithering with a 4‑bit palette
                rasterImage.Dither(DitheringMethod.ThresholdDithering, 4);

                // Save the dithered image as PDF
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a developer needs to convert high‑resolution Photoshop PSD files into compact PDF documents while preserving visual fidelity by applying ordered (threshold) dithering with a 4‑bit palette.
 * 2. When an automated batch‑processing service must generate printable PDFs from layered PSD assets and reduce file size using Aspose.Imaging’s Dither method before saving.
 * 3. When a web application offers users the ability to download their edited PSD artwork as a PDF and wants to ensure consistent monochrome rendering across different browsers by applying threshold dithering.
 * 4. When a digital archiving system requires converting legacy PSD files to PDF for long‑term storage and needs to apply ordered dithering to maintain detail in low‑color‑depth PDFs.
 * 5. When a C# desktop tool needs to validate that a loaded image is a raster image, apply a 4‑bit ordered dithering effect, and then export the result to PDF for inclusion in reports or invoices.
 */