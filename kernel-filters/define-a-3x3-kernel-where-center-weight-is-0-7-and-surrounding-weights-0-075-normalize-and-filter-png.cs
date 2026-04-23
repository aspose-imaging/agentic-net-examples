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

                // Define the 3x3 kernel with center weight 0.7 and surrounding 0.075, then normalize
                double center = 0.7;
                double surround = 0.075;
                double sum = center + 8 * surround; // 1.3
                double normalizedCenter = center / sum;      // ≈0.5384615
                double normalizedSurround = surround / sum;  // ≈0.0576923

                double[,] kernel = new double[3, 3]
                {
                    { normalizedSurround, normalizedSurround, normalizedSurround },
                    { normalizedSurround, normalizedCenter,  normalizedSurround },
                    { normalizedSurround, normalizedSurround, normalizedSurround }
                };

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the filtered image as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}