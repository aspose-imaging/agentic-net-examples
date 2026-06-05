using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                int pageIndex = 0;
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    page.Save(outputPath, new PngOptions());
                    pageIndex++;
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and save them as high‑quality PNG images for web publishing or digital archives.
 * 2. When an application must batch‑process scanned books in DjVu format and generate PNG files that can be easily displayed in browsers without requiring a DjVu viewer.
 * 3. When a workflow requires converting DjVu pages to PNG so that downstream image‑processing libraries such as OCR or thumbnail generators can operate on a widely supported raster format.
 * 4. When a developer wants to automate the conversion of DjVu technical manuals into PNG assets that can be embedded in mobile apps or e‑learning platforms.
 * 5. When a document management system needs to create PNG previews of each DjVu page to provide quick visual thumbnails for end‑users.
 */