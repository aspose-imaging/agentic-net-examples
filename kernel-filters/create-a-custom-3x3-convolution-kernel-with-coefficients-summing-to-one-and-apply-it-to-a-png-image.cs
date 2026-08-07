using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a 3x3 kernel with coefficients summing to 1 (average blur)
                double[,] kernel = new double[,]
                {
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                };

                // Create convolution filter options (factor = 1.0, bias = 0)
                var filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
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
 * 1. When a developer needs to apply a gentle average blur to a PNG thumbnail before displaying it in a web gallery to reduce visual noise.
 * 2. When an image‑processing pipeline must smooth scanned PNG documents to improve OCR accuracy without changing overall brightness.
 * 3. When a mobile app generates PNG icons and wants to soften edges using a 3×3 convolution kernel to achieve a consistent UI look across devices.
 * 4. When a batch job processes PNG screenshots and applies a uniform blur to mask sensitive details while preserving the original image dimensions.
 * 5. When a C# service integrates Aspose.Imaging to pre‑process PNG assets with a normalized convolution filter for downstream computer‑vision algorithms.
 */