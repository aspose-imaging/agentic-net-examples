// HOW-TO: Convert DjVu Pages 4 to 6 to BMP and Merge into PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDjvuPath = "input.djvu";
            string bmpOutputFolder = "bmp_pages";
            string outputPdfPath = "combined.pdf";

            // Validate input DjVu file
            if (!File.Exists(inputDjvuPath))
            {
                Console.Error.WriteLine($"File not found: {inputDjvuPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(bmpOutputFolder);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // List to hold BMP file paths
            List<string> bmpPaths = new List<string>();

            // Load DjVu document and extract pages 4-6 as BMP
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputDjvuPath))
            {
                for (int i = 3; i <= 5 && i < djvu.Pages.Length; i++)
                {
                    string bmpPath = Path.Combine(bmpOutputFolder, $"page_{i + 1}.bmp");
                    // Save page as BMP
                    djvu.Pages[i].Save(bmpPath, new BmpOptions());
                    bmpPaths.Add(bmpPath);
                }
            }

            // Collect sizes of BMP images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string bmpPath in bmpPaths)
            {
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    return;
                }
                using (RasterImage img = (RasterImage)Image.Load(bmpPath))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            // Calculate canvas size (vertical stacking)
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Create temporary canvas file
            string tempCanvasPath = Path.Combine(bmpOutputFolder, "canvas_temp.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));
            Source canvasSource = new FileCreateSource(tempCanvasPath, false);
            BmpOptions canvasOptions = new BmpOptions() { Source = canvasSource };
            using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string bmpPath in bmpPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(bmpPath))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }
                // Save the bound canvas BMP
                canvas.Save();
            }

            // Load the merged canvas and save as PDF
            if (!File.Exists(tempCanvasPath))
            {
                Console.Error.WriteLine($"File not found: {tempCanvasPath}");
                return;
            }
            using (RasterImage merged = (RasterImage)Image.Load(tempCanvasPath))
            {
                merged.Save(outputPdfPath, new PdfOptions());
            }

            // Optional: clean up temporary files
            // File.Delete(tempCanvasPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract specific pages from a multi‑page DjVu file and save them as high‑resolution BMP images for further processing or analysis.
 * 2. When you must create a printable PDF that contains only selected DjVu pages, converting them to BMP first to preserve image quality before merging.
 * 3. When an archival workflow requires converting scanned DjVu documents into BMP thumbnails and then bundling those thumbnails into a single PDF report.
 * 4. When a desktop application needs to programmatically generate PDF previews of particular DjVu pages for user review without loading the entire document.
 * 5. When automating batch conversion of DjVu chapters into BMP files and consolidating them into one PDF for distribution or e‑learning material.
 */
