// HOW-TO: Create Thumbnail Image and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.jpg");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage original = (RasterImage)Image.Load(inputPath))
            {
                if (!original.IsCached)
                    original.CacheData();

                int thumbWidth = 150;
                int thumbHeight = 150;
                original.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.Source = new FileCreateSource(outputPath, false);
                    original.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a small preview of a JPEG photo and embed it directly into a PDF report using C#.
 * 2. When an application must automatically create thumbnail‑sized images for document thumbnails and store them as PDF files without manual editing.
 * 3. When a web service processes uploaded raster images, resizes them to 150 × 150 pixels, and returns a PDF containing the thumbnail for easy viewing.
 * 4. When you want to batch‑convert a folder of high‑resolution images into lightweight PDF files that contain only a resized thumbnail for quick sharing.
 * 5. When integrating Aspose.Imaging in a C# workflow to embed a resized image into a PDF page for archival or email attachment purposes.
 */
