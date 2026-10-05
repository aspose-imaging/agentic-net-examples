// HOW-TO: Convert DjVu Pages 5 to 10 to TIFF in Parallel Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            var tasks = new List<System.Threading.Tasks.Task>();

            for (int pageIndex = 5; pageIndex <= 10; pageIndex++)
            {
                var task = System.Threading.Tasks.Task.Run(() =>
                {
                    using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                    {
                        if (pageIndex < 0 || pageIndex >= djvu.Pages.Length)
                        {
                            Console.Error.WriteLine($"Page index out of range: {pageIndex}");
                            return;
                        }

                        using (RasterImage pageImage = (RasterImage)djvu.Pages[pageIndex])
                        {
                            string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.tif");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                            pageImage.Save(outputPath, tiffOptions);
                        }
                    }
                });

                tasks.Add(task);
            }

            System.Threading.Tasks.Task.WaitAll(tasks.ToArray());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a specific range of pages from a DjVu file and save each as a high‑resolution TIFF for archival or printing.
 * 2. When you want to speed up batch conversion of DjVu pages by processing them concurrently on multiple CPU cores.
 * 3. When a document management system requires individual TIFF images for OCR or indexing of selected DjVu pages.
 * 4. When you are building a web service that receives DjVu uploads and must return TIFF files for pages 5‑10 on demand.
 * 5. When you must automate the creation of TIFF thumbnails from a DjVu document while ensuring the operation runs efficiently in a background task.
 */
