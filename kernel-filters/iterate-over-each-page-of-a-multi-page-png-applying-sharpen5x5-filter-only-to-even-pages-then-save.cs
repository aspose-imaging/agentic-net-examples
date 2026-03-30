using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multi‑page image
        using (Image image = Image.Load(inputPath))
        {
            // Check if the image supports multiple pages
            if (image is IMultipageImage multipageImage)
            {
                // Iterate over each page
                for (int i = 0; i < multipageImage.PageCount; i++)
                {
                    // Apply filter only to even‑indexed pages (0, 2, 4, ...)
                    if (i % 2 == 0)
                    {
                        Image page = multipageImage.Pages[i];
                        // Work with raster pages
                        if (page is RasterImage rasterPage)
                        {
                            // Apply Sharpen5x5 filter (size 5, sigma 4.0)
                            rasterPage.Filter(rasterPage.Bounds, new SharpenFilterOptions(5, 4.0));
                        }
                    }
                }
            }

            // Save the processed image as PNG
            var saveOptions = new PngOptions();
            image.Save(outputPath, saveOptions);
        }
    }
}