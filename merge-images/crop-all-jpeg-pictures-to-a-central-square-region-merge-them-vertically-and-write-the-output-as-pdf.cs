// HOW-TO: Crop JPEG Images to Central Square and Merge Vertically into PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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

            var jpegFiles = files.Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)).ToArray();

            if (jpegFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<int> squareSizes = new List<int>();

            foreach (var filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    int side = Math.Min(img.Width, img.Height);
                    squareSizes.Add(side);
                }
            }

            int canvasWidth = squareSizes.Max();
            int canvasHeight = squareSizes.Sum();

            string outputPath = Path.Combine(outputDirectory, "Merged.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegOptions jpegOptions = new JpegOptions())
            {
                using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
                {
                    // Fill background with white
                    int totalPixels = canvasWidth * canvasHeight;
                    int[] whitePixels = new int[totalPixels];
                    int whiteArgb = Aspose.Imaging.Color.White.ToArgb();
                    for (int i = 0; i < totalPixels; i++)
                        whitePixels[i] = whiteArgb;
                    canvas.SaveArgb32Pixels(new Rectangle(0, 0, canvasWidth, canvasHeight), whitePixels);

                    int offsetY = 0;
                    foreach (var filePath in jpegFiles)
                    {
                        if (!File.Exists(filePath))
                        {
                            Console.Error.WriteLine($"File not found: {filePath}");
                            return;
                        }

                        using (RasterImage img = (RasterImage)Image.Load(filePath))
                        {
                            int side = Math.Min(img.Width, img.Height);
                            int offsetX = (img.Width - side) / 2;
                            int offsetYImg = (img.Height - side) / 2;
                            img.Crop(new Rectangle(offsetX, offsetYImg, side, side));

                            int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                            canvas.SaveArgb32Pixels(new Rectangle(0, offsetY, side, side), pixels);
                            offsetY += side;
                        }
                    }

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
 * 1. When you need to create a printable PDF portfolio from a set of portrait‑oriented JPEG photos by cropping each to a centered square and stacking them vertically.
 * 2. When an e‑commerce site must generate a single PDF catalog page that shows product images uniformly cropped to square thumbnails arranged one below another.
 * 3. When a mobile app backend has to convert user‑uploaded JPEG selfies into a vertically merged PDF for easy sharing or archiving.
 * 4. When a reporting tool requires combining multiple scanned JPEG receipts into a single PDF document with each receipt displayed as a square image.
 * 5. When a document automation workflow needs to standardize varied‑size JPEG images, crop them to a central square, and merge them into a PDF for compliance documentation.
 */
