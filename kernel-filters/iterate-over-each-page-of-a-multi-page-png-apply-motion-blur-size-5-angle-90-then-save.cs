using System;
using System.IO;
using Aspose.Imaging;
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

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage != null)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        RasterImage page = multipage.Pages[i] as RasterImage;
                        if (page != null)
                        {
                            page.Filter(page.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(5, 1.0, 90.0));
                        }
                    }
                }

                PngOptions saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to apply a vertical motion blur effect to every frame of a multi‑page PNG (such as an animated PNG) before saving it as a new PNG file using C# and Aspose.Imaging.
 * 2. When an image‑processing pipeline must automatically enhance scanned document pages stored in a multi‑page PNG by adding a size‑5, 90‑degree motion blur to reduce scanning artifacts with Aspose.Imaging’s MotionWienerFilterOptions.
 * 3. When a graphics application requires batch processing of layered PNG assets, applying a consistent motion blur filter across all layers (pages) in C# and then exporting the result with PngOptions.
 * 4. When a developer is building a server‑side service that receives multi‑page PNG uploads, needs to uniformly blur each page for privacy or artistic effect, and must save the modified image using Aspose.Imaging’s Image.Load and Save methods.
 * 5. When a .NET utility must iterate through each page of a multi‑page PNG, apply a 5‑pixel motion blur at a 90‑degree angle to simulate camera movement, and output the processed image while preserving the original PNG format.
 */