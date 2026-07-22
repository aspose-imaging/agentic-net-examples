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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Process each page if the image is multipage
                if (image is IMultipageImage multipage && multipage.Pages != null)
                {
                    foreach (var page in multipage.Pages)
                    {
                        // Apply sharpen filter to raster pages
                        if (page is RasterImage rasterPage)
                        {
                            rasterPage.Filter(rasterPage.Bounds, new SharpenFilterOptions(5, 4.0));
                        }
                    }
                }
                else if (image is RasterImage rasterImage)
                {
                    // Single-page raster image
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
                }

                // Save the modified SVG
                image.Save(outputPath);
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
 * 1. When a developer needs to enhance the visual clarity of each frame in a multi‑page SVG diagram by applying a Sharpen3x3 filter before publishing it online.
 * 2. When an automated pipeline must process SVG assets generated from CAD software, sharpening each rasterized page to improve edge definition for high‑resolution printing.
 * 3. When a web application dynamically loads SVG icons that contain multiple frames and wants to apply consistent sharpening to all frames to maintain a crisp UI across browsers.
 * 4. When a batch conversion tool converts multi‑page SVG files to sharpened raster images for inclusion in PDF reports, requiring per‑page filter application in C#.
 * 5. When a developer integrates Aspose.Imaging into a CI/CD workflow to automatically sharpen every page of SVG assets stored in a repository before they are deployed to a marketing site.
 */