// HOW-TO: Apply Gaussian Blur to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.IMultipageImage multipage = image as Aspose.Imaging.IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The input image is not a multi-page image.");
                    return;
                }

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    using (Aspose.Imaging.Image page = multipage.Pages[i])
                    {
                        Aspose.Imaging.RasterImage raster = page as Aspose.Imaging.RasterImage;
                        if (raster != null)
                        {
                            var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 2.0);
                            raster.Filter(raster.Bounds, blurOptions);
                        }
                    }
                }

                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to soften the visual details of every frame in a multi‑page PNG before publishing it online.
 * 2. When you want to automatically blur sensitive information on each page of a scanned PDF saved as a PNG sequence using C#.
 * 3. When you are creating a stylized slideshow where each slide (PNG page) requires a consistent Gaussian blur effect applied programmatically.
 * 4. When you must preprocess multi‑page PNG assets for a game engine, applying a blur filter to reduce aliasing on all layers.
 * 5. When you are building a document‑processing pipeline that extracts, blurs, and re‑saves multi‑page PNG files with Aspose.Imaging in .NET.
 */
