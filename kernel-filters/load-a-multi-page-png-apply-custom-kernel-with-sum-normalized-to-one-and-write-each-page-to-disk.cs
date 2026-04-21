using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
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
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "output";
            // Ensure output directory exists before any save
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page PNG
            using (Image image = Image.Load(inputPath))
            {
                // Determine pages (handle both multipage and single‑page cases)
                List<Image> pages = new List<Image>();
                if (image is IMultipageImage multipage && multipage.Pages != null)
                {
                    foreach (var page in multipage.Pages)
                        pages.Add(page);
                }
                else
                {
                    pages.Add(image);
                }

                // Custom kernel (example 3x3) with sum normalized to 1
                double[,] kernel = new double[,]
                {
                    { 0.0, 0.2, 0.0 },
                    { 0.2, 0.2, 0.2 },
                    { 0.0, 0.2, 0.0 }
                };

                for (int i = 0; i < pages.Count; i++)
                {
                    // Cast each page to RasterImage for pixel operations
                    using (RasterImage raster = (RasterImage)pages[i])
                    {
                        // Apply convolution filter with the custom kernel
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                        // Prepare output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        // Ensure the directory for this file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the processed page as PNG
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