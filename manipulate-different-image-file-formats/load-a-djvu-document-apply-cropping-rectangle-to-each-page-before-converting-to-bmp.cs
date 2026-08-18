// HOW-TO: Crop Each Page of a DjVu File and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var cropRect = new Rectangle(10, 10, 200, 200);

            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                int pageIndex = 0;
                foreach (var page in djvuImage.Pages)
                {
                    pageIndex++;
                    page.Crop(cropRect);

                    string outputPath = $"output\\page{pageIndex}.bmp";

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    page.Save(outputPath, new BmpOptions());
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
 * 1. When you need to extract and crop individual pages from a multi‑page DjVu document to create separate BMP images for legacy printing systems.
 * 2. When a digital archive requires converting scanned DjVu pages into BMP format while removing unwanted margins for consistent display.
 * 3. When a document‑processing pipeline must batch‑process DjVu files, apply a fixed crop rectangle, and store the results as BMP files for further analysis.
 * 4. When a Windows application needs to preview cropped sections of DjVu pages by converting them to BMP bitmaps that GDI+ can render directly.
 * 5. When an OCR workflow demands pre‑cropped BMP images from DjVu sources to improve text‑recognition accuracy.
 */
