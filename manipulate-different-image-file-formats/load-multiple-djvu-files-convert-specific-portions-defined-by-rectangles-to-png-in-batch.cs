using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/page1.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                if (djvu.Pages.Length == 0)
                {
                    Console.Error.WriteLine("No pages found in Djvu file.");
                    return;
                }

                using (RasterImage page = (RasterImage)djvu.Pages[0])
                {
                    using (PngOptions options = new PngOptions())
                    {
                        page.Save(outputPath, options);
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
 * 1. When a developer needs to batch‑process a collection of DjVu documents to extract selected page regions defined by rectangles (e.g., a diagram area) and save them as PNG files for use in a web portal.
 * 2. When an archival system must convert specific portions of scanned historical manuscripts stored in DjVu format into PNG thumbnails for quick preview without loading the entire document.
 * 3. When a publishing workflow requires extracting the title block from each page of a multi‑page DjVu file and converting those cropped sections to PNG for automated metadata generation.
 * 4. When a legal‑tech application needs to programmatically pull signature areas defined by rectangles from DjVu case files and store them as PNG images for verification and audit trails.
 * 5. When a mobile app backend must generate PNG assets from selected regions of DjVu e‑books (such as cover art or illustration snippets) in bulk to reduce client‑side processing and bandwidth usage.
 */