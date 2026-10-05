// HOW-TO: Scale DjVu Page and Convert to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\scaled.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                var page = djvu.Pages[0];
                int originalWidth = page.Width;
                int originalHeight = page.Height;

                double scale = 2.0;
                int newWidth = (int)(originalWidth * scale);
                int newHeight = (int)(originalHeight * scale);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);

                using (TiffImage canvas = (TiffImage)Image.Create(tiffOptions, newWidth, newHeight))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(page, 0, 0, newWidth, newHeight);
                    canvas.Save();
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
 * 1. When you need to display a high‑resolution version of a scanned DjVu document in a Windows application, you can scale the page and save it as a TIFF file.
 * 2. When a document‑management system requires TIFF images for archival but receives DjVu files, this code converts and enlarges the pages to meet the archive’s quality standards.
 * 3. When generating printable assets from DjVu manuals, developers can proportionally enlarge the pages and output them as TIFF to preserve detail for large‑format printing.
 * 4. When integrating Aspose.Imaging into a batch‑processing pipeline that extracts DjVu pages, rescales them, and stores the results as TIFF for downstream OCR processing.
 * 5. When creating thumbnails or preview images for DjVu content, you can resize the original page and convert it to TIFF to ensure compatibility with viewers that only support TIFF.
 */
