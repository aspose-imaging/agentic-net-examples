using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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

            // Define a custom sharpening kernel (3x3 example)
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Calculate the sum of kernel elements
            double sum = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    sum += kernel[i, j];
                }
            }

            // Validate that the kernel sum exceeds one for brightness increase
            if (sum <= 1)
            {
                Console.Error.WriteLine("Kernel sum must be greater than 1 to increase brightness.");
                return;
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply the custom sharpening filter using the kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the processed image as PNG
                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                rasterImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to enhance the perceived sharpness and brightness of product photos stored as PNG files before uploading them to an e‑commerce site, they can use this code to apply a custom convolution kernel and ensure the kernel sum exceeds one.
 * 2. When an automated image‑processing pipeline must validate input images and apply a brightness‑boosting sharpening filter to scanned documents in PNG format, this snippet provides the necessary file checks and kernel‑sum validation.
 * 3. When a desktop application written in C# has to let users improve the clarity of PNG screenshots by applying a user‑defined sharpening matrix while guaranteeing a brightness increase, the code demonstrates how to compute and enforce the kernel sum condition.
 * 4. When a batch‑processing script needs to process a folder of PNG assets for a video game, increasing both edge definition and overall luminance using Aspose.Imaging’s convolution filter, the example shows how to verify the kernel sum before filtering.
 * 5. When a developer integrates custom image‑enhancement features into a medical imaging viewer that works with PNG slices, they can use this code to ensure the custom sharpening kernel raises brightness, preventing under‑exposed results.
 */