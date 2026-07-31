// HOW-TO: Crop JPEG Images to Central Square and Merge Vertically into PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
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
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Gather JPEG files
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (jpegFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // First pass: determine square side lengths
            List<int> sideLengths = new List<int>();
            foreach (string filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    int side = Math.Min(img.Width, img.Height);
                    sideLengths.Add(side);
                }
            }

            int canvasWidth = sideLengths.Max();
            int canvasHeight = sideLengths.Sum();

            // Prepare output PDF path
            string outputPath = Path.Combine(outputDirectory, "Merged.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create an unbound canvas (JPEG image) to hold merged content
            using (JpegOptions canvasOptions = new JpegOptions())
            {
                using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
                {
                    int offsetY = 0;

                    // Second pass: load, crop, and copy each image onto the canvas
                    foreach (string filePath in jpegFiles)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(filePath))
                        {
                            int side = Math.Min(img.Width, img.Height);
                            int left = (img.Width - side) / 2;
                            int top = (img.Height - side) / 2;

                            // Crop to central square
                            img.Crop(new Rectangle(left, top, side, side));

                            // Destination rectangle on the canvas
                            Rectangle destRect = new Rectangle(0, offsetY, side, side);

                            // Copy pixel data
                            canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));

                            offsetY += side;
                        }
                    }

                    // Save the merged canvas as PDF
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        canvas.Save(outputPath, pdfOptions);
                    }
                }
            }

            Console.WriteLine($"Merged PDF created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create a printable PDF portfolio from a set of portrait‑oriented JPEG photos by cropping each to a square and stacking them vertically.
 * 2. When an e‑commerce site wants to generate a single PDF catalog page from product JPEG images that must be uniformly square.
 * 3. When a mobile app prepares a PDF slideshow of user‑uploaded photos, ensuring each image is centered and square before merging.
 * 4. When a reporting tool converts scanned JPEG receipts into a compact PDF where each receipt is cropped to its central square region.
 * 5. When an automated workflow batch‑processes JPEG screenshots, crops them to a consistent square size, and combines them into a single PDF document for archival.
 */
