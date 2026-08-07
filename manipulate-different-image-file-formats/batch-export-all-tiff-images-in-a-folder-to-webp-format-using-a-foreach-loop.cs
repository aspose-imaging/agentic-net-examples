using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            string[] tiffFiles = Directory.GetFiles(inputDir, "*.*")
                .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in tiffFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".webp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new WebPOptions();
                    image.Save(outputPath, options);
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
 * 1. When a developer needs to convert a large archive of high‑resolution TIFF scans into smaller WebP files for faster web page loading.
 * 2. When an image processing pipeline must automatically generate WebP thumbnails from TIFF source files stored in a shared folder.
 * 3. When a digital asset management system requires periodic batch conversion of TIFF photographs to WebP to reduce storage costs while preserving visual quality.
 * 4. When a C# application has to migrate legacy TIFF documents to a modern web‑friendly format without manual intervention.
 * 5. When a server‑side script must ensure all incoming TIFF uploads are saved as WebP for consistent delivery across browsers.
 */