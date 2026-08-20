// HOW-TO: Check PNG File Size After Applying Emboss Filter in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output_embossed.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage png = (PngImage)Image.Load(inputPath))
            {
                // Record original file size
                long originalSize = new FileInfo(inputPath).Length;

                // Apply emboss filter using convolution kernel
                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                png.Filter(png.Bounds, embossOptions);

                // Prepare PNG save options
                PngOptions saveOptions = new PngOptions
                {
                    // Use adaptive filtering for better compression
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive,
                    CompressionLevel = 9,
                    // Preserve original dimensions and color type
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    BitDepth = 8
                };

                // Save the filtered image
                png.Save(outputPath, saveOptions);

                // Record new file size
                long newSize = new FileInfo(outputPath).Length;

                // Output size comparison
                Console.WriteLine($"Original size: {originalSize} bytes");
                Console.WriteLine($"Embossed size: {newSize} bytes");
                if (newSize > originalSize * 1.5)
                {
                    Console.WriteLine("Warning: File size increased dramatically after emboss filtering.");
                }
                else
                {
                    Console.WriteLine("File size increase is within acceptable range.");
                }
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
 * 1. When you need to verify that applying an emboss convolution to a PNG does not cause the file to grow beyond acceptable limits before uploading to a web server.
 * 2. When you want to compare original and filtered PNG sizes to ensure compression settings keep the image under a specific bandwidth budget.
 * 3. When you are automating a batch process that adds an emboss effect and must log size changes to maintain storage quotas.
 * 4. When you integrate image filtering into a C# application and need to confirm that adaptive PNG filtering and maximum compression keep the output size stable.
 * 5. When you are testing image quality pipelines and require a quick C# script to detect unexpected file‑size spikes after applying a 3×3 emboss kernel.
 */
