using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output\\blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                // Prepare rasterization options for SVG
                var rasterOptions = new SvgRasterizationOptions();

                // Prepare PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image
                    using (Aspose.Imaging.Image rasterImageContainer = Aspose.Imaging.Image.Load(memoryStream))
                    {
                        var rasterImage = (Aspose.Imaging.RasterImage)rasterImageContainer;

                        // Apply a predefined Gaussian blur filter (radius 5, sigma 4.0)
                        rasterImage.Filter(
                            rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                        // Save the blurred raster image
                        rasterImage.Save(outputPath);
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
 * 1. When generating thumbnail previews of vector logos for a web gallery, a developer can rasterize the SVG and apply a Gaussian blur to create a soft‑focus PNG preview.
 * 2. When preparing background assets for a mobile app, a developer may need to blur SVG icons to reduce visual noise and then export them as PNGs for faster rendering.
 * 3. When implementing a privacy filter that obscures sensitive details in SVG diagrams, a developer can use the Gaussian blur filter to mask information before sharing the image.
 * 4. When creating stylized UI elements such as blurred buttons or cards, a developer can convert SVG shapes to raster images, apply a predefined blur, and save the result as a PNG for use in XAML layouts.
 * 5. When automating batch processing of SVG illustrations for print‑ready PDFs, a developer can apply a consistent blur effect to each image to achieve a uniform aesthetic across the document.
 */