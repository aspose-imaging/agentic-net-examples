using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize the SVG into a raster image using an in‑memory PNG
                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, new PngOptions());
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Apply Gaussian blur filter (size = 5, sigma = 4.0)
                        var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                        raster.Filter(raster.Bounds, blurOptions);

                        // Save the processed image
                        raster.Save(outputPath);
                    }
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
 * 1. When a web developer needs to generate a blurred PNG thumbnail from an SVG logo for a website loading screen, they can rasterize the SVG and apply a Gaussian blur filter using C# and Aspose.Imaging.
 * 2. When a desktop application must create a soft‑focus background image from vector artwork, it can load the SVG, convert it to a raster image, and apply a Gaussian blur before saving as PNG.
 * 3. When an e‑commerce platform automatically produces privacy‑preserving preview images, it can rasterize product SVG illustrations and use a Gaussian blur filter to obscure details while keeping the file format as PNG.
 * 4. When a game engine pipeline converts SVG icons to raster PNGs and wants to simulate depth‑of‑field, it can apply a Gaussian blur via ConvolutionFilter.Apply during the C# image processing step.
 * 5. When a reporting tool needs to de‑emphasize SVG charts as watermarks behind text, it can rasterize the SVG, apply a Gaussian blur filter, and save the result as a PNG overlay.
 */