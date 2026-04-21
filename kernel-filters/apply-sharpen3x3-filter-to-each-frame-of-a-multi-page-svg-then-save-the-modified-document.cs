using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image (may be multi‑page)
            using (Image image = Image.Load(inputPath))
            {
                // If the image supports multiple pages, process each one
                if (image is IMultipageImage multipageImage && multipageImage.Pages != null)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        // Access the current page
                        var page = multipageImage.Pages[i];

                        // Attempt to treat the page as a raster image for filtering
                        if (page is RasterImage rasterPage)
                        {
                            // Apply Sharpen filter to the entire page
                            rasterPage.Filter(rasterPage.Bounds, new SharpenFilterOptions());
                        }
                    }
                }
                else if (image is RasterImage rasterImage)
                {
                    // Single‑page raster image case
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions());
                }

                // Save the modified SVG document
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}