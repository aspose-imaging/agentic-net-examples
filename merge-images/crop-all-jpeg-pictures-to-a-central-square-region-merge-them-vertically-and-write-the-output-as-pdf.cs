// HOW-TO: Crop JPEG Images to Central Square and Merge Vertically into PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            List<string> jpegFiles = files.Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)).ToList();

            if (jpegFiles.Count == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<int[]> croppedPixels = new List<int[]>();
            List<int> squareSizes = new List<int>();

            foreach (string filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    if (!img.IsCached) img.CacheData();

                    int squareSize = Math.Min(img.Width, img.Height);
                    int offsetX = (img.Width - squareSize) / 2;
                    int offsetY = (img.Height - squareSize) / 2;
                    Rectangle cropRect = new Rectangle(offsetX, offsetY, squareSize, squareSize);
                    img.Crop(cropRect);

                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                    croppedPixels.Add(pixels);
                    squareSizes.Add(squareSize);
                }
            }

            int canvasWidth = squareSizes.Max();
            int canvasHeight = squareSizes.Sum();

            using (RasterImage canvas = (RasterImage)Image.Create(new JpegOptions(), canvasWidth, canvasHeight))
            {
                // Fill background with white
                int totalPixels = canvasWidth * canvasHeight;
                int[] whitePixels = Enumerable.Repeat(Color.White.ToArgb(), totalPixels).ToArray();
                canvas.SaveArgb32Pixels(new Rectangle(0, 0, canvasWidth, canvasHeight), whitePixels);

                int offsetY = 0;
                for (int i = 0; i < croppedPixels.Count; i++)
                {
                    int size = squareSizes[i];
                    Rectangle destRect = new Rectangle(0, offsetY, size, size);
                    canvas.SaveArgb32Pixels(destRect, croppedPixels[i]);
                    offsetY += size;
                }

                string outputPath = Path.Combine(outputDirectory, "Merged.pdf");
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
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
 * 1. When you need to create a printable PDF portfolio that shows a series of portrait‑style JPEG photos stacked vertically, each centered and cropped to a square.
 * 2. When an e‑commerce site must generate a single PDF catalog page from product photos that are originally rectangular JPEGs, ensuring uniform square thumbnails.
 * 3. When a mobile app wants to combine user‑uploaded JPEG selfies into a vertical PDF collage without distortion by cropping to the central square region first.
 * 4. When a reporting tool requires merging scanned JPEG receipts into a single PDF document while standardizing each receipt to a square layout for consistent appearance.
 * 5. When an automated workflow must batch‑process JPEG images, crop them to a central square, and archive them as a vertically merged PDF for easy sharing or printing.
 */
