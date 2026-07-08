using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
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
                SvgImage svgImage = (SvgImage)image;

                // Rotate the SVG by 45 degrees clockwise
                svgImage.Rotate(45f);

                // Prepare rasterization options for PNG output
                var pngOptions = new PngOptions();
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    // Use the original SVG size for rasterization
                    PageSize = svgImage.Size
                };
                pngOptions.VectorRasterizationOptions = rasterizationOptions;

                // Rasterize the rotated SVG into a memory stream
                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Gaussian blur filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the final blurred image to the output path
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
 * 1. When creating a web thumbnail that shows a rotated logo with a soft focus effect, a developer can use this code to rotate the SVG 45° and apply Gaussian blur before exporting to PNG.
 * 2. When generating print‑ready marketing material where a vector illustration needs to be tilted and slightly blurred to simulate depth‑of‑field, this snippet handles the rotation and blur in C#.
 * 3. When building an image‑processing pipeline for a mobile app that overlays a blurred, rotated SVG watermark onto photos, the code provides the necessary transformation and rasterization steps.
 * 4. When preparing assets for a game UI where icons must appear at an angle with a subtle glow achieved via Gaussian blur, developers can employ this example to process SVG icons into PNG sprites.
 * 5. When automating batch conversion of SVG diagrams into blurred, rotated PNGs for a data‑visualization dashboard, this routine lets you rotate each diagram 45° and apply a uniform blur filter programmatically.
 */