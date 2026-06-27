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
            string outputPath = "output\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a 3x3 sharpening kernel
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };
            double factor = 1.0;
            int bias = 0;

            // Load image and apply custom convolution filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, factor, bias);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to automatically sharpen a batch of PNG screenshots before uploading them to a documentation portal, they can use this utility to apply a 3x3 sharpening kernel to each image.
 * 2. When an image processing pipeline requires custom edge‑enhancement on scanned PDF pages saved as PNG, the command‑line tool can receive the convolution matrix as arguments and process the files without manual editing.
 * 3. When a CI/CD build script must validate visual quality of generated UI assets by applying a specific filter and comparing the result, the utility provides a C#‑based, scriptable way to run the convolution filter on the PNG output.
 * 4. When a developer is creating a lightweight image preprocessing step for a machine‑learning model that expects sharpened input, they can invoke the program with custom kernel coefficients to prepare the raster images on the fly.
 * 5. When a Windows service needs to periodically improve the contrast of security camera snapshots stored as PNG files, the command‑line application can be scheduled to run with different bias and factor values supplied at runtime.
 */