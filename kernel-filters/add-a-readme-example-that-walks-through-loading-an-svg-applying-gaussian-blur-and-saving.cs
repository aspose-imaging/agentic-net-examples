using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

namespace SvgGaussianBlurExample
{
    // README EXAMPLE
    // This example demonstrates how to:
    // 1. Load an SVG image from a file.
    // 2. Rasterize the SVG to a PNG image.
    // 3. Apply a Gaussian blur filter to the rasterized image.
    // 4. Save the blurred image to a new file.
    //
    // The code follows strict path‑safety rules:
    // - Input and output paths are hard‑coded string literals.
    // - The existence of the input file is verified with File.Exists.
    // - The output directory is created unconditionally before saving.
    // - All operations are wrapped in a try/catch block to report errors gracefully.

    class Program
    {
        static void Main()
        {
            // Hard‑coded paths (do not use args)
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output_blurred.png";

            try
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // -----------------------------------------------------------------
                // Step 1: Load the SVG image from the file stream
                // -----------------------------------------------------------------
                using (FileStream svgStream = File.OpenRead(inputPath))
                using (SvgImage svgImage = new SvgImage(svgStream))
                {
                    // -----------------------------------------------------------------
                    // Step 2: Rasterize the SVG to a PNG image in memory
                    // -----------------------------------------------------------------
                    // Configure rasterization options (default DPI, size based on SVG)
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        // You can set Width/Height/Dpi if needed; defaults are used here
                    };

                    // Prepare PNG save options and attach rasterization settings
                    PngOptions pngSaveOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the rasterized PNG to a memory stream
                    using (MemoryStream rasterizedStream = new MemoryStream())
                    {
                        svgImage.Save(rasterizedStream, pngSaveOptions);
                        rasterizedStream.Position = 0; // Reset for reading

                        // -----------------------------------------------------------------
                        // Step 3: Load the rasterized PNG as a RasterImage to apply filter
                        // -----------------------------------------------------------------
                        using (Image rasterImage = Image.Load(rasterizedStream))
                        {
                            // Cast to RasterImage (the loaded PNG is a raster image)
                            RasterImage raster = (RasterImage)rasterImage;

                            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                            // -----------------------------------------------------------------
                            // Step 4: Save the blurred image to the final output path
                            // -----------------------------------------------------------------
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
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate a blurred thumbnail from an SVG logo for use in UI placeholders.
 * 2. When an e‑commerce platform wants to create a soft‑focus product badge by rasterizing vector icons to PNG and applying a Gaussian blur.
 * 3. When a reporting tool must convert scalable diagrams into blurred background images for PDF reports using C# and Aspose.Imaging.
 * 4. When a mobile app backend processes user‑uploaded SVG avatars, rasterizes them to PNG, and adds a Gaussian blur for privacy masking.
 * 5. When a digital signage system prepares blurred promotional graphics by loading SVG assets, rasterizing them, and saving the result as PNG files.
 */