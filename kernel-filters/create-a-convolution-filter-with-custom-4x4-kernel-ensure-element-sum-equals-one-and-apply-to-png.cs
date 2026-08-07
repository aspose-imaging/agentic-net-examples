using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom 4x4 kernel whose elements sum to 1
                double[,] kernel = new double[,]
                {
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 }
                };

                // Create convolution filter options (factor = 1.0, bias = 0)
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

                // Apply the convolution filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to uniformly blur a PNG image in a .NET application by applying a custom 4×4 averaging convolution kernel using Aspose.Imaging.
 * 2. When a C# program must perform lightweight noise reduction on PNG assets before uploading them to a web service, using a normalized convolution filter to preserve overall brightness.
 * 3. When an image‑processing pipeline requires consistent smoothing across the entire raster image while ensuring the pixel values remain within the original dynamic range, achieved by a sum‑to‑one kernel in Aspose.Imaging.
 * 4. When a developer wants to replace a built‑in blur filter with a custom 4×4 kernel to fine‑tune the smoothing effect on PNG screenshots in a Windows desktop tool.
 * 5. When automating batch processing of PNG files, a .NET script can apply a normalized convolution filter to each image to create a soft‑focus effect without altering the file format.
 */