using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output_emboss.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (PngImage png = new PngImage(inputPath))
            {
                // Record original file size
                long originalSize = new FileInfo(inputPath).Length;

                // Create emboss filter options (Convolution filter with Emboss3x3 kernel)
                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

                // Apply the emboss filter to the whole image
                png.Filter(png.Bounds, embossOptions);

                // Save the filtered image with adaptive PNG filtering for better compression
                var saveOptions = new PngOptions
                {
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive
                };
                png.Save(outputPath, saveOptions);

                // Record output file size
                long outputSize = new FileInfo(outputPath).Length;

                Console.WriteLine($"Original size: {originalSize} bytes");
                Console.WriteLine($"Embossed size: {outputSize} bytes");

                // Simple check for dramatic size increase (e.g., more than double)
                if (outputSize > originalSize * 2)
                {
                    Console.WriteLine("Warning: PNG file size increased dramatically after emboss filtering.");
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
 * 1. A developer uses this code to verify that applying an emboss convolution filter to a PNG image does not cause the file size to exceed a set limit for web publishing.
 * 2. This snippet helps a developer compare original and embossed PNG sizes to decide if the filtered image is suitable for bandwidth‑constrained mobile applications.
 * 3. In a batch‑processing pipeline, a developer employs the code to ensure the Aspose.Imaging emboss filter does not double the PNG file size before archiving the results.
 * 4. An automated quality‑check script can use this example to flag PNG files whose size grows dramatically after applying a 3×3 emboss filter.
 * 5. A C# utility that applies adaptive PNG compression after embossing can use this code to confirm the output remains within storage constraints.
 */