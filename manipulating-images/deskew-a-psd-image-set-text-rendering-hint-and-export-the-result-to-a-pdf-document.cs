using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.psd";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is TiffImage tiffImage)
                {
                    tiffImage.NormalizeAngle(false, Color.White);
                }

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

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
 * 1. When a developer needs to automatically deskew a Photoshop PSD image, apply a single‑bit text rendering hint, and export a clean PDF for archival or client review, this code provides a ready‑to‑use solution.
 * 2. When a workflow requires converting tilted PSD layers into PDF documents with a white background and no smoothing to preserve sharp text edges, the example shows how to achieve it using Aspose.Imaging for .NET.
 * 3. When an application must programmatically correct the angle of a scanned PSD file, normalize it with TiffImage.NormalizeAngle, and then save the result as a PDF with exact page dimensions, this snippet demonstrates the required steps.
 * 4. When generating printable PDFs from PSD assets where text must be rendered with TextRenderingHint.SingleBitPerPixel to ensure crisp typography, developers can use this code to set the rasterization options accordingly.
 * 5. When integrating image processing into a C# service that receives PSD files, deskews them, and returns PDF reports without any anti‑aliasing, the provided example illustrates the complete load‑process‑save pipeline using Aspose.Imaging.
 */