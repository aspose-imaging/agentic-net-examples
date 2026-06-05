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
            string inputPath = "input.svg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG rendering
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };

                // Prepare PNG options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Render SVG to a raster image via an in-memory PNG
                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rendered raster image
                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        // Apply a Gaussian blur (radius 5, sigma 4.0)
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                        // Set high-quality JPEG options
                        var jpegOptions = new JpegOptions
                        {
                            Quality = 95
                        };

                        // Save the blurred image as JPEG
                        raster.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to create a soft‑edge blurred thumbnail of an SVG logo for a responsive web gallery, they can load the vector, apply a Gaussian blur, and export it as a high‑quality JPEG.
 * 2. When a marketing application must generate preview images of vector illustrations with a subtle blur effect for email newsletters, this code loads the SVG, blurs it, and saves a JPEG optimized for email clients.
 * 3. When an e‑commerce platform wants to display blurred background images derived from product SVG graphics behind product details, the code rasterizes the SVG, applies a soft blur, and outputs a JPEG suitable for fast loading.
 * 4. When a desktop publishing tool needs to convert vector artwork into a JPEG with a smooth blur for print‑ready mockups, the snippet loads the SVG, applies a Gaussian blur filter, and saves a high‑resolution JPEG.
 * 5. When an automated batch process must generate blurred preview JPEGs from a library of SVG icons for a mobile app’s splash screen, this code handles loading, blurring, and high‑quality JPEG export in C#.
 */