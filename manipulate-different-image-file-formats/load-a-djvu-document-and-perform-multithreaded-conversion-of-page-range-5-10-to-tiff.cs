// HOW-TO: Convert DjVu Pages 5 to 10 to TIFF Using Parallel C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            Parallel.ForEach(System.Linq.Enumerable.Range(5, 6), pageIndex =>
            {
                string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.tif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (FileStream stream = File.OpenRead(inputPath))
                {
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        using (Image page = djvuImage.Pages[pageIndex])
                        {
                            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                            page.Save(outputPath, tiffOptions);
                        }
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a specific range of pages from a multi‑page DjVu document and save each page as a separate TIFF file for archival or printing.
 * 2. When you want to speed up conversion of large DjVu files by processing multiple pages concurrently on a multi‑core server.
 * 3. When an application must generate TIFF images for pages 5‑10 of a scanned book to feed into OCR or document management systems.
 * 4. When you are building a batch‑processing pipeline that reads DjVu files from disk and outputs high‑resolution TIFFs for downstream image analysis.
 * 5. When you need to ensure the output directory structure exists before saving each converted page, handling missing files gracefully in a C# service.
 */
