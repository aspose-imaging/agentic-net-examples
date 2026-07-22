using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (kernel size 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Configure PNG compression options (maximum compression)
                PngOptions pngOptions = new PngOptions
                {
                    CompressionLevel = 9,
                    // Optional: choose a filter type for better compression
                    // FilterType = PngFilterType.Adaptive,
                    // Optional: enable progressive loading
                    // Progressive = true
                };

                // Save the processed image with compression
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When a web developer wants to test how much a Gaussian‑blurred PNG can be reduced in size before uploading it to a content‑delivery network, they can use this C# code with Aspose.Imaging to apply the blur and save the image with maximum compression.
 * 2. When a mobile app team needs to generate low‑bandwidth preview thumbnails by smoothing the original PNG and then compressing it at level 9, this example shows the exact steps in .NET.
 * 3. When a data‑science pipeline evaluates the trade‑off between visual quality loss from a Gaussian blur and file‑size savings in PNG format, the code demonstrates how to automate the process in C#.
 * 4. When an e‑commerce platform wants to pre‑process product photos with a subtle blur to hide sensitive details and then store them as highly compressed PNGs, this snippet provides the required filter and compression settings.
 * 5. When a QA engineer is benchmarking Aspose.Imaging’s PNG compression efficiency on blurred images to compare against other libraries, the sample illustrates loading, filtering, and saving the image using C#.
 */