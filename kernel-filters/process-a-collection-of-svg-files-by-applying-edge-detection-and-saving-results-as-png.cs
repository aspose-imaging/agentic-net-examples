// HOW-TO: Batch Apply Edge Detection to SVG Files and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "InputSvgs";
            string outputDirectory = "OutputPngs";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all SVG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                // Check if the file exists (redundant after GetFiles but follows the rule)
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set up rasterization options for SVG to PNG conversion
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Rasterize SVG to a memory stream (PNG format)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load the rasterized PNG as a RasterImage
                        using (Image rasterImageContainer = Image.Load(ms))
                        {
                            var rasterImage = (RasterImage)rasterImageContainer;

                            // Edge detection kernel (simple Laplacian)
                            double[,] kernel = new double[,]
                            {
                                { -1, -1, -1 },
                                { -1,  8, -1 },
                                { -1, -1, -1 }
                            };

                            // Apply convolution filter for edge detection
                            var filterOptions = new ConvolutionFilterOptions(kernel);
                            rasterImage.Filter(rasterImage.Bounds, filterOptions);

                            // Prepare output path
                            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the processed image as PNG
                            var finalPngOptions = new PngOptions();
                            rasterImage.Save(outputPath, finalPngOptions);
                        }
                    }
                }

                Console.WriteLine($"Processed and saved: {Path.GetFileName(inputPath)}");
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
 * 1. When a developer needs to automatically convert a folder of vector SVG icons into raster PNG images with edge detection for use in web thumbnails.
 * 2. When a batch image processing pipeline must prepare SVG diagrams for machine‑learning models that require edge‑enhanced PNG inputs.
 * 3. When an application generates SVG charts and wants to export them as high‑contrast PNGs for inclusion in PDF reports.
 * 4. When a CI/CD build step must transform design assets from SVG to PNG while highlighting edges for visual regression testing.
 * 5. When a desktop tool needs to bulk‑process user‑uploaded SVG files, apply edge detection, and store the results as PNGs for faster rendering on low‑power devices.
 */
