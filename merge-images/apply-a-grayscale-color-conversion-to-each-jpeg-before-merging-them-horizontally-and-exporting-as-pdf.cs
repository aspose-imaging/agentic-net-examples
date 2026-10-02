// HOW-TO: Convert Multiple JPEGs to Grayscale and Merge Horizontally into PDF in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<RasterImage> images = new List<RasterImage>();
            List<Size> sizes = new List<Size>();

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                RasterImage img = (RasterImage)Image.Load(filePath);
                img.Grayscale();
                images.Add(img);
                sizes.Add(img.Size);
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            string tempImagePath = Path.Combine(outputDirectory, "temp.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempImagePath));

            Source source = new FileCreateSource(tempImagePath, false);
            JpegOptions jpegOptions = new JpegOptions { Source = source };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (RasterImage img in images)
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }

                canvas.Save();

                string outputPdfPath = Path.Combine(outputDirectory, "merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPdfPath, pdfOptions);
            }

            foreach (RasterImage img in images)
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
 * 1. When you need to create a printable PDF catalog from a series of color JPEG photos by first converting them to black‑and‑white and placing them side‑by‑side.
 * 2. When generating a grayscale contact sheet of product images for a marketing brochure, merging the images horizontally before saving as PDF.
 * 3. When automating archival of scanned receipts where each JPEG must be desaturated and combined into a single PDF document for easy storage.
 * 4. When building a web service that receives user‑uploaded JPEGs, converts them to grayscale, stitches them into one wide image, and returns a PDF report.
 * 5. When preparing documentation that requires all screenshots to be in grayscale and displayed in a single horizontal layout inside a PDF file.
 */
