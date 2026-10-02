// HOW-TO: Convert DjVu Pages to Scaled PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    int pageWidth = djvu.Pages[i].Width;
                    int pageHeight = djvu.Pages[i].Height;
                    Console.WriteLine($"Page {i + 1}: {pageWidth}x{pageHeight}");

                    const int maxWidth = 1000;
                    double scale = pageWidth > maxWidth ? (double)maxWidth / pageWidth : 1.0;
                    int newWidth = (int)(pageWidth * scale);
                    int newHeight = (int)(pageHeight * scale);

                    string tempPngPath = Path.Combine(outputDir, $"temp_page_{i}.png");
                    var pngOptions = new PngOptions();
                    djvu.Pages[i].Save(tempPngPath, pngOptions);

                    using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                    {
                        if (scale != 1.0)
                        {
                            raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                        }

                        string finalPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        raster.Save(finalPath, pngOptions);
                    }

                    if (File.Exists(tempPngPath))
                    {
                        File.Delete(tempPngPath);
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
 * 1. When you need to batch‑convert a multi‑page DjVu document into individual PNG files that fit within a specific width for web display.
 * 2. When you want to preserve the original aspect ratio of each DjVu page while automatically resizing large pages to a maximum pixel width.
 * 3. When an application must read the dimensions of each DjVu page to decide whether scaling is required before saving as PNG.
 * 4. When you are integrating Aspose.Imaging into a C# service that generates thumbnail‑size PNG previews from high‑resolution DjVu scans.
 * 5. When you have to programmatically extract and resize DjVu pages for inclusion in a PDF or HTML report without manual image editing.
 */
