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
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image (or any multi‑page vector image)
            using (Image image = Image.Load(inputPath))
            {
                // If the image supports multiple pages, process each page
                if (image is IMultipageImage multipage)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        // Retrieve the page as an Image
                        Image page = multipage.Pages[i];

                        // Apply Sharpen filter only to raster pages
                        if (page is RasterImage raster)
                        {
                            raster.Filter(raster.Bounds, new SharpenFilterOptions());
                        }
                    }
                }
                else if (image is RasterImage rasterImage)
                {
                    // Single‑page raster image: apply filter directly
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions());
                }

                // Save the modified document back to SVG format
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}