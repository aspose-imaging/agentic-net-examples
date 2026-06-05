using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputOriginalPath = "output_original.png";
            string outputBlurPath = "output_blur.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputOriginalPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputBlurPath));

            // Load the SVG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                // Configure rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Rasterize SVG to a PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(ms))
                    {
                        Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)rasterImg;

                        // Save the original raster image
                        rasterImage.Save(outputOriginalPath, new PngOptions());

                        // Apply Gaussian blur filter
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the blurred image
                        rasterImage.Save(outputBlurPath, new PngOptions());
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
 * 1. When a developer needs to confirm that applying a Gaussian blur to a rasterized SVG does not create visual artifacts before publishing the PNG on a responsive website.
 * 2. When a developer wants to automate regression testing of vector‑based logos by comparing the original rasterized PNG with a blurred version to ensure edge fidelity.
 * 3. When a developer integrates Aspose.Imaging in a C# build pipeline to validate that SVG icons retain crispness after Gaussian blur processing for mobile app assets.
 * 4. When a developer creates a quality‑control script that loads an SVG, rasterizes it to PNG, applies a blur filter, and checks for unwanted pixel distortion in printed marketing materials.
 * 5. When a developer builds a preview tool that shows both the original and blurred PNG outputs of an SVG to verify that the blur effect does not introduce aliasing or color banding in UI components.
 */