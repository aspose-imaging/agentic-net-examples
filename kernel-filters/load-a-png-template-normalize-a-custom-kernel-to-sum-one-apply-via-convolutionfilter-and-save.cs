using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = "template.png";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom kernel (3x3)
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Normalize kernel so that the sum equals 1
            double sum = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
                for (int j = 0; j < kernel.GetLength(1); j++)
                    sum += kernel[i, j];

            if (sum != 0)
            {
                for (int i = 0; i < kernel.GetLength(0); i++)
                    for (int j = 0; j < kernel.GetLength(1); j++)
                        kernel[i, j] /= sum;
            }

            // Create convolution filter options (factor=1.0, bias=0)
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

            // Load the PNG template, apply the filter, and save the result
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, filterOptions);

                // Save with default PNG options
                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to sharpen the edges of a PNG template for a web banner, this code loads the PNG, normalizes a custom kernel, applies a convolution filter, and saves the enhanced image.
 * 2. When an application must preprocess user‑uploaded PNG logos to ensure consistent brightness before further analysis, the snippet demonstrates kernel normalization, convolution filtering with Aspose.Imaging, and PNG output.
 * 3. When a reporting tool generates PNG charts that require a subtle contrast boost, a developer can use this code to load the chart image, apply a normalized 3×3 kernel, and save the improved PNG.
 * 4. When an e‑commerce platform wants to automatically apply a custom emboss effect to product PNG thumbnails, this example shows how to perform the effect using Aspose.Imaging’s ConvolutionFilterOptions and save the result.
 * 5. When a desktop utility needs to batch‑process PNG templates to prepare them for OCR by reducing noise with a custom filter, the code provides a C# pattern for loading, normalizing, filtering, and saving each PNG image.
 */