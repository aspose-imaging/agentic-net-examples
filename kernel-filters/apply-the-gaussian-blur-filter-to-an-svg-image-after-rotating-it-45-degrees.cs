using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage to access vector-specific methods
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Failed to load SVG image.");
                    return;
                }

                // Rotate the SVG by 45 degrees
                svgImage.Rotate(45f);

                // Prepare rasterization options for converting SVG to raster format
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Set up PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize the rotated SVG into a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0; // Reset stream position for reading

                    // Load the rasterized image from the memory stream
                    using (Image rasterImage = Image.Load(ms))
                    {
                        // Cast to RasterImage to apply filters
                        RasterImage raster = rasterImage as RasterImage;
                        if (raster == null)
                        {
                            Console.Error.WriteLine("Failed to rasterize SVG image.");
                            return;
                        }

                        // Apply Gaussian blur filter to the entire image
                        GaussianBlurFilterOptions blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                        raster.Filter(raster.Bounds, blurOptions);

                        // Save the final blurred image to the output path
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
 * 1. When a web application needs to generate a thumbnail of a user‑uploaded SVG logo that is rotated 45° and softened with a Gaussian blur before saving it as a PNG for faster page loads.
 * 2. When an e‑learning platform wants to programmatically create diagram overlays where each SVG illustration is rotated for visual emphasis and then blurred to serve as a background watermark in PNG format.
 * 3. When a desktop publishing tool automates the preparation of print‑ready assets by rotating vector icons, applying a Gaussian blur to achieve a drop‑shadow effect, and exporting them as high‑resolution PNGs using Aspose.Imaging for .NET.
 * 4. When a mobile game engine processes SVG assets at runtime, rotating them to match character orientation, applying a Gaussian blur for motion‑blur simulation, and converting them to raster PNGs for texture mapping.
 * 5. When a data‑visualization service dynamically generates rotated and blurred SVG charts to embed in PDF reports, converting the final image to PNG with Aspose.Imaging to ensure consistent rendering across platforms.
 */