using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Apng;

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

            using (Image image = Image.Load(inputPath))
            {
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("Input image is not a multi-page PNG (APNG).");
                    return;
                }

                for (int i = 0; i < apng.PageCount; i++)
                {
                    RasterImage page = apng.Pages[i] as RasterImage;
                    if (page != null)
                    {
                        page.Filter(page.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                    }
                }

                ApngOptions saveOptions = new ApngOptions();
                apng.Save(outputPath, saveOptions);
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
 * 1. When you need to automatically blur sensitive content (e.g., faces or license plates) across every frame of an animated PNG (APNG) before publishing it online.
 * 2. When you want to apply a consistent Gaussian blur effect to each page of a multi‑page PNG to create a smooth, stylized animation for a mobile app splash screen.
 * 3. When you must preprocess a sequence of PNG frames by reducing high‑frequency noise with a Gaussian blur before feeding them into a computer‑vision model.
 * 4. When you are generating low‑resolution preview thumbnails of an APNG and need to soften the image details uniformly across all pages for faster loading.
 * 5. When you are converting a series of raster images into an APNG and want to ensure every frame has the same blur radius to maintain visual continuity in a web banner.
 */