// HOW-TO: Resize PNG to 800x800 with Transparent Padding and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/padded.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Calculate scaling to fit within 800x800 while preserving aspect ratio
                double scale = Math.Min(800.0 / sourceImage.Width, 800.0 / sourceImage.Height);
                int resizedWidth = (int)(sourceImage.Width * scale);
                int resizedHeight = (int)(sourceImage.Height * scale);

                // Resize source image
                sourceImage.Resize(resizedWidth, resizedHeight, ResizeType.NearestNeighbourResample);

                // Create a transparent 800x800 canvas
                using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions(), 800, 800))
                {
                    canvas.BackgroundColor = Color.Transparent;
                    canvas.HasTransparentColor = true;

                    // Center the resized image on the canvas
                    int offsetX = (800 - resizedWidth) / 2;
                    int offsetY = (800 - resizedHeight) / 2;

                    canvas.SaveArgb32Pixels(
                        new Rectangle(offsetX, offsetY, resizedWidth, resizedHeight),
                        sourceImage.LoadArgb32Pixels(sourceImage.Bounds));

                    // Save canvas as PDF
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        canvas.Save(outputPath, pdfOptions);
                    }
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
 * 1. When generating product catalog pages that require all images to be a uniform 800x800 size with transparent borders before embedding them into a PDF brochure.
 * 2. When preparing user‑uploaded PNG avatars for a web application that must be resized, padded to a square canvas, and stored as PDF for archival.
 * 3. When creating printable PDF reports that include icons or logos, ensuring each image fits a fixed square dimension without distortion and retains transparency.
 * 4. When automating the conversion of varied‑size PNG assets into a standardized PDF format for batch printing or e‑signature workflows.
 * 5. When building a C# service that normalizes images for a mobile app, resizing them to 800×800, adding transparent padding, and delivering them as PDF files to reduce client‑side processing.
 */
