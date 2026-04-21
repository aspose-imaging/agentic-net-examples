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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Process only if the image supports multiple pages
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        // Apply filter to even‑indexed pages (0, 2, 4, ...)
                        if (i % 2 == 0)
                        {
                            if (multipageImage.Pages[i] is RasterImage rasterPage)
                            {
                                // Sharpen filter with kernel size 5 and sigma 1.0
                                rasterPage.Filter(
                                    rasterPage.Bounds,
                                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 1.0));
                            }
                        }
                    }
                }

                // Save the modified image using PNG options
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