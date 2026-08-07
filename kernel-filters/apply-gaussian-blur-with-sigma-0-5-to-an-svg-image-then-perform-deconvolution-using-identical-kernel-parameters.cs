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
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load rasterized image
                    using (Image rasterImageContainer = Image.Load(rasterStream))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Gaussian blur with radius 1 and sigma 0.5
                        var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(1, 0.5);
                        rasterImage.Filter(rasterImage.Bounds, blurOptions);

                        // Apply deconvolution using identical kernel parameters
                        var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(1, 0.5);
                        rasterImage.Filter(rasterImage.Bounds, deconvOptions);

                        // Save final image
                        PngOptions saveOptions = new PngOptions();
                        rasterImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to generate a softened preview thumbnail of an SVG logo for a web gallery while preserving the ability to restore original sharpness using deconvolution.
 * 2. When a C# application must preprocess vector icons into PNG assets with a subtle blur to reduce aliasing before applying a Wiener deconvolution to enhance edge definition for high‑DPI displays.
 * 3. When an automated build pipeline converts SVG diagrams to PNG screenshots, applies a low‑sigma Gaussian blur to simulate printing diffusion, and then reverses it with a matching deconvolution filter to test image quality.
 * 4. When a UI designer wants to create a blurred background effect from SVG artwork in a Windows Forms app, using Aspose.Imaging to rasterize, blur, and then sharpen the image with identical kernel parameters.
 * 5. When a scientific visualization tool needs to simulate optical blur on vector‑based microscopy images and subsequently restore detail by applying a Gauss‑Wiener deconvolution in C#.
 */