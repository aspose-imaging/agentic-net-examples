// HOW-TO: Apply Custom Convolution Filter To Each Page Of Multi-Page PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputDir = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page PNG
            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        // Process each page as a RasterImage
                        using (RasterImage raster = (RasterImage)multipageImage.Pages[i])
                        {
                            // Custom 3×3 kernel normalized to sum = 1
                            double[,] kernel = new double[,]
                            {
                                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                                { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                            };

                            // Apply convolution filter
                            var filterOptions = new ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, filterOptions);

                            // Prepare output file path for the current page
                            string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");

                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the processed page as PNG
                            var saveOptions = new PngOptions();
                            raster.Save(outputPath, saveOptions);
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
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
 * 1. When you need to smooth or blur every frame of an animated PNG before saving each frame as a separate image file.
 * 2. When you want to preprocess each page of a multi‑page scanned document with a uniform averaging kernel for consistent noise reduction.
 * 3. When you are building a thumbnail generator that extracts and lightly filters each page of a multi‑page PNG for a gallery view.
 * 4. When you must apply the same custom convolution filter to all layers of a PNG sprite sheet and export them individually.
 * 5. When you are preparing multi‑page PNG assets for a machine‑learning pipeline that requires each page to be normalized and saved separately.
 */
