using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "templates/input.png";
            string outputPath = "output/blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image and apply a 5x5 blur box filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Convolution filter with a predefined 5x5 blur box kernel
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(5));

                raster.Filter(raster.Bounds, blurOptions);
                raster.Save(outputPath);
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
 * 1. When a C# developer needs to generate a soft‑focused PNG background for a web page, they can load the template image and apply a 5x5 blur box filter using Aspose.Imaging.
 * 2. When an application must anonymize sensitive details in a PNG screenshot before sharing, the code can rasterize the image and blur it with a predefined 5x5 convolution filter.
 * 3. When preparing product photos for print, a developer can use this snippet to apply a subtle blur to PNG assets, ensuring consistent visual quality across catalogs.
 * 4. When creating thumbnail previews with smooth edges for a gallery, the code loads the original PNG and applies the 5x5 blur box filter to reduce sharpness before resizing.
 * 5. When pre‑processing PNG images for a computer‑vision pipeline, a developer can use the Aspose.Imaging convolution filter to reduce noise by applying a 5x5 blur box to the raster image.
 */