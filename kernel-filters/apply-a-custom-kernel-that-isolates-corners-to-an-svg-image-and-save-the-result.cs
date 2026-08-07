using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Check input file existence
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
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image as RasterImage
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Define a custom kernel that isolates corners
                        double[,] kernel = new double[,]
                        {
                            { 1, 0, 1 },
                            { 0, 0, 0 },
                            { 1, 0, 1 }
                        };

                        // Apply convolution filter with the custom kernel
                        ConvolutionFilterOptions convOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, convOptions);

                        // Save the filtered raster image as PNG
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to preprocess vector icons by highlighting only their corner points for a computer‑vision feature‑extraction pipeline, they can rasterize the SVG with Aspose.Imaging, apply a custom corner‑isolating convolution kernel, and save the result as a PNG.
 * 2. When an e‑commerce platform wants to generate thumbnail previews that emphasize product logo corners for better visual distinction, the code can convert SVG logos to raster images, filter out non‑corner areas, and store the output in PNG format.
 * 3. When a UI designer requires a quick way to create edge‑aware masks from SVG assets for overlay effects, they can use the custom kernel to isolate corners, producing a PNG mask that can be composited in the application.
 * 4. When a machine‑learning team prepares training data by extracting corner features from scalable diagrams, the code rasterizes each SVG, applies the corner‑detecting filter, and saves the processed images for model ingestion.
 * 5. When a developer builds an automated quality‑control tool that flags SVG files with missing or malformed corners, they can run this routine to isolate corners, compare the output PNG against expected patterns, and report anomalies.
 */