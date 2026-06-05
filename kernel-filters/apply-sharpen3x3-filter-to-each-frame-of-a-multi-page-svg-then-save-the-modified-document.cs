using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\multiframe.svg";
        string outputPath = @"C:\Images\multiframe_sharpened.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Check if the image supports multiple pages
                if (image is IMultipageImage multipage && multipage.Pages != null)
                {
                    // Iterate over each page/frame
                    foreach (var page in multipage.Pages)
                    {
                        // Cast the page to RasterImage to apply raster filters
                        if (page is RasterImage rasterPage)
                        {
                            // Apply Sharpen filter to the entire page
                            rasterPage.Filter(rasterPage.Bounds, new SharpenFilterOptions());
                        }
                    }
                }

                // Save the modified SVG document
                image.Save(outputPath, new SvgOptions());
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
 * 1. When a web application needs to enhance the visual clarity of each layer in a multi‑page SVG icon set before delivering it to browsers, a developer can use this code to apply a 3×3 sharpen filter to every frame and save the optimized SVG.
 * 2. When an automated graphics pipeline processes vector illustrations that contain multiple pages (e.g., multi‑page diagrams) and must improve edge definition without converting to raster formats, this snippet lets a C# developer sharpen each page in‑place using Aspose.Imaging.
 * 3. When a desktop publishing tool imports multi‑frame SVG assets and wants to ensure that printed output shows crisp details on every page, the code can be integrated to apply the Sharpen3x3 filter to each rasterized frame before saving.
 * 4. When a batch job iterates over a collection of SVG files with several frames and needs to programmatically enhance their sharpness for a digital signage system, the example demonstrates how to load, filter, and re‑save each SVG using C# and Aspose.Imaging.
 * 5. When a SaaS platform offers users the ability to upload multi‑page SVG logos and automatically improves their visual quality for thumbnails, this code provides a straightforward way to apply a sharpen filter to each page and store the result.
 */