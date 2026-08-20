// HOW-TO: Apply JSON Kernel Settings to Batch Convert SVG to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string configPath = "config.json";
            string inputDir = "input_svgs";
            string outputDir = "output";

            // Validate config file
            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            // Read and deserialize configuration
            string json = File.ReadAllText(configPath);
            Config config = JsonSerializer.Deserialize<Config>(json);

            // Get SVG files
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"File not found: {inputDir}");
                return;
            }

            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load SVG vector image
                using (Image vectorImage = Image.Load(inputPath))
                {
                    // Rasterization options for SVG
                    VectorRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = vectorImage.Size
                    };

                    // Rasterize SVG to PNG in memory
                    using (MemoryStream rasterStream = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };
                        vectorImage.Save(rasterStream, pngOptions);
                        byte[] rasterBytes = rasterStream.ToArray();

                        // Apply each filter defined in the configuration
                        foreach (FilterDefinition filterDef in config.Filters)
                        {
                            // Prepare a fresh raster image for each filter
                            using (MemoryStream ms = new MemoryStream(rasterBytes))
                            using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                            {
                                // Create appropriate filter options
                                FilterOptionsBase filterOptions = null;
                                string filterType = filterDef.Type?.Trim().ToLowerInvariant();

                                if (filterType == "sharpen")
                                {
                                    filterOptions = new SharpenFilterOptions(
                                        filterDef.Size ?? 5,
                                        filterDef.Sigma ?? 1.0);
                                }
                                else if (filterType == "gaussianblur")
                                {
                                    filterOptions = new GaussianBlurFilterOptions(
                                        filterDef.Size ?? 5,
                                        filterDef.Sigma ?? 1.0);
                                }
                                else if (filterType == "bilateralsmoothing")
                                {
                                    filterOptions = new BilateralSmoothingFilterOptions(
                                        filterDef.Size ?? 5);
                                }
                                else if (filterType == "gausswiener")
                                {
                                    filterOptions = new GaussWienerFilterOptions(
                                        filterDef.Size ?? 5,
                                        filterDef.Sigma ?? 1.0);
                                }
                                else if (filterType == "motionwiener")
                                {
                                    filterOptions = new MotionWienerFilterOptions(
                                        filterDef.Length ?? 10,
                                        filterDef.Smooth ?? 1.0,
                                        filterDef.Angle ?? 0.0);
                                }
                                else
                                {
                                    // Unsupported filter type; skip
                                    continue;
                                }

                                // Apply filter to the entire image
                                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                                // Prepare output path
                                string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_{filterDef.Type}.png";
                                string outputPath = Path.Combine(outputDir, outputFileName);

                                // Ensure output directory exists
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                                // Save filtered image as PNG
                                rasterImage.Save(outputPath, new PngOptions());
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

    // Configuration classes for JSON deserialization
    private class Config
    {
        public List<FilterDefinition> Filters { get; set; }
    }

    private class FilterDefinition
    {
        public string Type { get; set; }
        public int? Size { get; set; }
        public double? Sigma { get; set; }
        public int? Length { get; set; }
        public double? Smooth { get; set; }
        public double? Angle { get; set; }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to read custom rasterization parameters from a JSON file and automatically convert dozens of SVG icons to PNG for a web project.
 * 2. When a build pipeline must apply the same image filter settings stored in a configuration file to all vector assets before publishing.
 * 3. When you want to programmatically rasterize SVG logos with consistent page size and output format using Aspose.Imaging in a C# console application.
 * 4. When an e‑commerce platform requires bulk conversion of product SVG illustrations to PNG thumbnails while preserving settings defined by designers in JSON.
 * 5. When a desktop tool has to validate the existence of input SVG files, load them, and generate PNG previews based on configurable kernel options.
 */
