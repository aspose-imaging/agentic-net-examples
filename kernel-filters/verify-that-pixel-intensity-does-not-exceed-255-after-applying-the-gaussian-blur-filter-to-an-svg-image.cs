// HOW-TO: Check Pixel Intensity After Gaussian Blur on SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image.
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG.
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Prepare PNG save options with the rasterization settings.
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG to a memory stream.
                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image as a RasterImage.
                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Gaussian blur filter (size=5, sigma=4.0).
                        rasterImage.Filter(rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                        // Verify that pixel intensity does not exceed 255.
                        bool intensityOk = true;
                        for (int y = 0; y < rasterImage.Height && intensityOk; y++)
                        {
                            for (int x = 0; x < rasterImage.Width; x++)
                            {
                                Aspose.Imaging.Color color = rasterImage.GetPixel(x, y);
                                if (color.R > 255 || color.G > 255 || color.B > 255 || color.A > 255)
                                {
                                    intensityOk = false;
                                    break;
                                }
                            }
                        }

                        if (!intensityOk)
                        {
                            Console.Error.WriteLine("Pixel intensity exceeds 255 after applying Gaussian blur.");
                            return;
                        }

                        // Save the processed image.
                        rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When converting an SVG logo to a PNG thumbnail and applying a Gaussian blur, you need to ensure the resulting pixel values stay within the 0‑255 range.
 * 2. When preparing blurred background images for a web page, verifying intensity prevents overflow artifacts after rasterizing vector graphics.
 * 3. When building an automated pipeline that processes SVG icons with Aspose.Imaging, checking pixel intensity after filtering guarantees valid PNG output for downstream tools.
 * 4. When performing scientific visualization that requires precise grayscale limits, confirming that Gaussian blur does not exceed 255 maintains data integrity.
 * 5. When creating print‑ready assets from SVG illustrations, validating pixel intensity after blur helps avoid color banding and ensures compliance with PNG specifications.
 */
