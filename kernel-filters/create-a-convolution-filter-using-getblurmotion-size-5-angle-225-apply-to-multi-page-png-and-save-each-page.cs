using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/apng_image.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        using (RasterImage page = (RasterImage)multipageImage.Pages[i])
                        {
                            double[,] kernel = ConvolutionFilter.GetBlurMotion(5, 225);
                            page.Filter(page.Bounds, new ConvolutionFilterOptions(kernel));

                            string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            page.Save(outputPath, new PngOptions());
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
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
 * 1. When a developer needs to add a directional motion blur effect to each frame of an animated PNG (APNG) for smoother visual transitions in web animations.
 * 2. When a developer wants to preprocess multi‑page PNG scans by applying a 5‑pixel, 225‑degree blur to reduce noise before OCR or archival storage.
 * 3. When a developer is building a C# image‑processing pipeline that extracts individual pages from a multi‑page PNG and saves them as separate PNG files with a consistent convolution filter applied.
 * 4. When a developer must programmatically enhance the visual consistency of a series of PNG layers in a game asset by applying the same motion blur kernel across all layers.
 * 5. When a developer is creating a batch conversion tool that loads an APNG, applies a custom convolution filter using Aspose.Imaging, and outputs each page as a standalone PNG for further editing in graphic design software.
 */