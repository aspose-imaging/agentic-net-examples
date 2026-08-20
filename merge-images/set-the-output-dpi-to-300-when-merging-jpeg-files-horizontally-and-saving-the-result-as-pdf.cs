// HOW-TO: Merge JPEG Images Horizontally Into PDF With 300 DPI In C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<int> widths = new List<int>();
            List<int> heights = new List<int>();
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            int newWidth = widths.Sum();
            int newHeight = heights.Max();

            using (JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 100,
                ResolutionSettings = new ResolutionSetting(300, 300),
                ResolutionUnit = ResolutionUnit.Inch
            })
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string file in files)
                {
                    using (RasterImage img = (RasterImage)Image.Load(file))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                string pdfPath = Path.Combine(outputDirectory, "merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                using (PdfOptions pdfOptions = new PdfOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                })
                {
                    canvas.Save(pdfPath, pdfOptions);
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
 * 1. When you need to combine multiple scanned JPEG pages into a single high‑resolution PDF for printing or archiving.
 * 2. When generating a printable catalog where each product photo (JPEG) must appear side‑by‑side on one PDF page at 300 DPI.
 * 3. When creating a PDF report that stitches together screenshots saved as JPEGs while preserving print‑quality resolution.
 * 4. When automating the preparation of legal documents that require merged JPEG evidence images in a single PDF with exact DPI settings.
 * 5. When developing a web service that receives JPEG uploads, merges them horizontally, and returns a 300‑DPI PDF for downstream workflow.
 */
