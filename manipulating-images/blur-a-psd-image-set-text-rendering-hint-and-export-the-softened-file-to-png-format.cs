using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Apply Gaussian blur if the image is raster
                if (image is RasterImage raster)
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                }

                // Prepare PNG export options with text rendering hint
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to soften a Photoshop PSD layer before generating a web‑ready PNG thumbnail, applying a Gaussian blur and preserving text clarity with a specific rendering hint.
 * 2. When an automated pipeline must convert high‑resolution PSD designs into PNG assets for mobile apps while ensuring any embedded vector text is rasterized with single‑bit per pixel rendering for consistent appearance.
 * 3. When a content management system imports user‑uploaded PSD files, applies a blur effect to hide sensitive details, and saves the result as a PNG for fast preview loading.
 * 4. When a batch‑processing tool processes a folder of PSD files, adds a subtle Gaussian blur to background elements, and exports them to PNG with Aspose.Imaging’s TextRenderingHint to maintain crisp typography.
 * 5. When a digital publishing workflow requires converting layered PSD artwork into PNG images with controlled text rasterization, using C# and Aspose.Imaging to apply blur and set the rendering hint in one step.
 */