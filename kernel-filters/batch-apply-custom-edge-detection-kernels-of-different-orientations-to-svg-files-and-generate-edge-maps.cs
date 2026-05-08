using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories relative to the current directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            // Define custom edge‑detection kernels
            var kernels = new Dictionary<string, double[,]>
            {
                { "Horizontal", new double[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } } },
                { "Vertical",   new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } } }
            };

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set up rasterization options for SVG -> PNG conversion
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Prepare PNG save options with the rasterization settings
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.VectorRasterizationOptions = rasterOptions;

                        // Rasterize SVG to a memory stream
                        using (MemoryStream pngStream = new MemoryStream())
                        {
                            svgImage.Save(pngStream, pngOptions);
                            byte[] pngBytes = pngStream.ToArray();

                            // Apply each kernel to a fresh raster copy
                            foreach (var kvp in kernels)
                            {
                                string orientation = kvp.Key;
                                double[,] kernel = kvp.Value;

                                // Load raster image from the PNG bytes
                                using (MemoryStream rasterStream = new MemoryStream(pngBytes))
                                using (Image rasterImg = Image.Load(rasterStream))
                                {
                                    RasterImage raster = (RasterImage)rasterImg;

                                    // Apply convolution filter with the custom kernel
                                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                                    // Build output path
                                    string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}_{orientation}_edge.png");

                                    // Ensure output directory exists
                                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                                    // Save the edge map as PNG
                                    using (PngOptions saveOptions = new PngOptions())
                                    {
                                        raster.Save(outputPath, saveOptions);
                                    }
                                }
                            }
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