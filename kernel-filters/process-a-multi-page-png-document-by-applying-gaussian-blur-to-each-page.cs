using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image (could be multi‑page PNG)
            using (Image image = Image.Load(inputPath))
            {
                // Check if the loaded image supports multiple pages
                if (image is IMultipageImage multipageImage)
                {
                    // Apply Gaussian blur to each page
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        // Each page is an Image; cast to RasterImage for filtering
                        RasterImage rasterPage = (RasterImage)multipageImage.Pages[i];
                        rasterPage.Filter(rasterPage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                    }

                    // Save the processed multi‑page PNG
                    PngOptions saveOptions = new PngOptions();
                    image.Save(outputPath, saveOptions);
                }
                else
                {
                    // Single‑page PNG handling
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image
                    PngOptions saveOptions = new PngOptions();
                    raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to automatically apply a Gaussian blur to every page of a multi‑page PNG invoice using Aspose.Imaging for .NET before archiving it.
 * 2. When a web service must blur sensitive details across all frames of an animated multi‑page PNG by applying a Gaussian blur filter with C#.
 * 3. When a batch‑processing script has to reduce background noise on each sheet of a multi‑page PNG blueprint scan by applying a Gaussian blur via Aspose.Imaging.
 * 4. When a document‑management system requires smoothing of all pages in a multi‑page PNG report to improve OCR results, using the GaussianBlurFilterOptions in C#.
 * 5. When a desktop utility generates preview thumbnails by adding a uniform Gaussian blur to each page of a multi‑page PNG e‑book with Aspose.Imaging for .NET.
 */