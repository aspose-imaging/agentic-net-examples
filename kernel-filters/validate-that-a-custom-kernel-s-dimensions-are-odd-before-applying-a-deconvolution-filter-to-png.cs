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

            // Load PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the processed image
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
 * 1. When a developer needs to sharpen a PNG photograph by applying a deconvolution filter with a custom kernel, they must first verify that the kernel’s width and height are odd numbers to satisfy Aspose.Imaging’s requirement.
 * 2. When processing scanned documents in a C# application and using a custom deconvolution kernel to enhance text clarity, the code must check that the kernel dimensions are odd before saving the result as a PNG.
 * 3. When building an automated pipeline that reduces blur in satellite PNG images using Aspose.Imaging’s deconvolution filter, validating odd kernel dimensions prevents runtime errors and ensures correct convolution alignment.
 * 4. When creating a medical imaging tool that applies a custom deconvolution filter to PNG X‑ray images, developers need to confirm the kernel size is odd to maintain the filter’s symmetry and avoid artifacts.
 * 5. When developing a batch image‑processing script in .NET that applies custom deconvolution kernels to PNG assets for a game’s texture optimization, checking for odd kernel dimensions is essential before invoking the Aspose.Imaging filter.
 */