using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder (non‑recursive)
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Prepare rasterization options for SVG -> raster conversion
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Save the rasterized image to a memory stream as PNG
                    using (var pngStream = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterizationOptions
                        };
                        svgImage.Save(pngStream, pngOptions);
                        pngStream.Position = 0; // Reset stream position for reading

                        // Load the rasterized PNG as a RasterImage to apply the filter
                        using (Image rasterImg = Image.Load(pngStream))
                        {
                            var rasterImage = (RasterImage)rasterImg;

                            // Apply Gaussian blur with size 5 (odd) and sigma 2.0
                            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 2.0));

                            // Build output file path (same name with .png extension)
                            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                            string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + "_blur.png");

                            // Ensure the output directory exists (already created above, but follow rule)
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the processed image
                            rasterImage.Save(outputPath);
                        }
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
 * 1. When a web designer needs to automatically blur a collection of SVG icons before publishing them as PNG assets for a mobile app, they can use this C# batch code with Aspose.Imaging to rasterize and apply a Gaussian blur with sigma 2.0.
 * 2. When a marketing team wants to create a set of stylized background images by blurring multiple SVG illustrations and saving them as PNGs for email campaigns, the code provides a fast, repeatable solution in .NET.
 * 3. When a GIS analyst must preprocess a folder of vector map overlays by softening edges with a Gaussian blur before overlaying them on raster maps, this Aspose.Imaging script handles the SVG‑to‑PNG conversion and blur in one pass.
 * 4. When an e‑learning platform generates thumbnail previews of SVG diagrams and wants each preview to have a subtle blur effect for visual consistency, the batch processing code automates loading, rasterizing, and filtering all files in a directory.
 * 5. When a game developer prepares texture atlases from SVG assets and needs to apply a uniform Gaussian blur with sigma 2.0 to all images to achieve a specific art style, the C# example streamlines the bulk conversion and filtering workflow.
 */