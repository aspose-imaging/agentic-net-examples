using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Output PDF path
            string outputPdfPath = Path.Combine(outputDirectory, "merged.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Collect JPEG files
            string[] allFiles = Directory.GetFiles(inputDirectory, "*.*");
            List<JpegImage> croppedImages = new List<JpegImage>();

            foreach (string filePath in allFiles)
            {
                // Validate file existence
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string ext = Path.GetExtension(filePath).ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg")
                    continue; // Skip non‑JPEG files

                // Load JPEG image
                JpegImage img = (JpegImage)Image.Load(filePath);

                // Determine central square region
                int squareSize = Math.Min(img.Width, img.Height);
                int offsetX = (img.Width - squareSize) / 2;
                int offsetY = (img.Height - squareSize) / 2;
                Rectangle cropRect = new Rectangle(offsetX, offsetY, squareSize, squareSize);

                // Crop to central square
                img.Crop(cropRect);

                // Store for later merging
                croppedImages.Add(img);
            }

            if (croppedImages.Count == 0)
            {
                Console.WriteLine("No JPEG images found to process.");
                return;
            }

            // Calculate canvas size for vertical merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (JpegImage img in croppedImages)
            {
                if (img.Width > canvasWidth) canvasWidth = img.Width;
                canvasHeight += img.Height;
            }

            // Create an unbound raster canvas
            using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions(), canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (JpegImage img in croppedImages)
                {
                    // Center each image horizontally if widths differ
                    int offsetX = (canvasWidth - img.Width) / 2;
                    Rectangle destRect = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }

                // Save merged result as PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPdfPath, pdfOptions);
            }

            // Dispose loaded images
            foreach (JpegImage img in croppedImages)
            {
                img.Dispose();
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
 * 1. When a photographer wants to create a portfolio PDF that shows only the central square portion of each JPEG thumbnail stacked vertically for a clean, uniform presentation.
 * 2. When an e‑commerce platform needs to generate a printable PDF catalog by cropping product photos to a square focus area and merging them in a vertical list for easy browsing.
 * 3. When a mobile app backend processes user‑uploaded JPEG avatars, extracts the central square, and compiles them into a single PDF report for moderation or analytics.
 * 4. When a real‑estate agency prepares a PDF brochure that displays the central square view of each property’s JPEG image one after another to maintain consistent layout.
 * 5. When a document management system automatically converts a folder of scanned JPEG receipts into a vertically merged PDF, cropping each receipt to its central square to remove background noise.
 */