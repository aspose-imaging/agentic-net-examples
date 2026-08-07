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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output_emboss.png";

        try
        {
            // Verify input file exists
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
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply emboss filter using convolution kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Set PNG save options with interlaced (progressive) encoding
                PngOptions options = new PngOptions
                {
                    Progressive = true
                };

                // Save the processed image
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to generate a progressive (interlaced) PNG thumbnail with an emboss effect for faster web page rendering, they can use this code.
 * 2. When testing how the Aspose.Imaging convolution filter interacts with PNG's progressive encoding to ensure visual consistency across browsers, this example is applicable.
 * 3. When creating an automated image processing pipeline that applies a 3×3 emboss kernel to PNG assets before saving them with interlaced compression for progressive loading, the code provides a ready‑to‑use solution.
 * 4. When debugging a bug where the emboss filter appears distorted after saving a PNG with the Progressive flag enabled, a developer can run this snippet to reproduce and isolate the issue.
 * 5. When building a C# desktop application that lets users apply artistic emboss filters to PNG files and preview them with interlaced loading for large images, this sample demonstrates the required steps.
 */