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
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize using high‑quality bicubic interpolation (CubicConvolution)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Apply Gaussian blur filter
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the result as SVG
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size }
                };
                image.Save(outputPath, svgOptions);
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
 * 1. When a web developer needs to generate a scalable SVG version of a high‑resolution PNG thumbnail for responsive UI, they can resize the PNG with bicubic interpolation, blur it, and save as SVG.
 * 2. When an e‑commerce platform wants to create smooth, blurred product icons that scale without pixelation across devices, they can use this code to enlarge the PNG, apply Gaussian blur, and export to SVG.
 * 3. When a mobile app needs to pre‑process user‑uploaded PNG avatars by doubling their size, softening edges with a Gaussian blur, and converting them to vector SVG for faster rendering, this snippet provides the solution.
 * 4. When a publishing workflow requires converting high‑quality PNG illustrations into SVG graphics while applying a subtle blur effect for background images, developers can employ this code.
 * 5. When a digital signage system must upscale PNG logos, add a Gaussian blur for a glow effect, and store them as SVG files for infinite scaling on large displays, this code handles the task.
 */