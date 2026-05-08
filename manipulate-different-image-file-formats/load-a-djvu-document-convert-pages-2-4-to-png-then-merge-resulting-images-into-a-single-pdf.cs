using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Input DjVu file path (hardcoded)
            string inputPath = Path.Combine(inputDirectory, "document.djvu");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // List to hold generated PNG file paths
            List<string> pngPaths = new List<string>();

            // Load DjVu document and export pages 2‑4 as PNG
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 2; i <= 4; i++)
                {
                    if (i >= djvu.PageCount)
                        break;

                    string pngPath = Path.Combine(outputDirectory, $"page_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(pngPath, false)
                    };

                    ((DjvuPage)djvu.Pages[i]).Save(pngPath, pngOptions);
                    pngPaths.Add(pngPath);
                }
            }

            if (pngPaths.Count == 0)
            {
                Console.WriteLine("No pages were exported.");
                return;
            }

            // Calculate canvas size for vertical merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (string path in pngPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    if (img.Width > canvasWidth)
                        canvasWidth = img.Width;
                    canvasHeight += img.Height;
                }
            }

            // Create temporary merged PNG canvas
            string tempCanvasPath = Path.Combine(outputDirectory, "merged_temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

            PngOptions canvasOptions = new PngOptions
            {
                Source = new FileCreateSource(tempCanvasPath, false)
            };

            using (PngImage canvas = (PngImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string pngPath in pngPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(pngPath))
                    {
                        Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save merged canvas as PDF
                string pdfPath = Path.Combine(outputDirectory, "merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(pdfPath, pdfOptions);
            }

            Console.WriteLine($"PDF created at: {Path.Combine(outputDirectory, "merged.pdf")}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}