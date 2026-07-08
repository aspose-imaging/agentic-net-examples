using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "output_emboss.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load original PNG
            using (PngImage png = (PngImage)Image.Load(inputPath))
            {
                long originalSize = new FileInfo(inputPath).Length;

                // Apply emboss filter
                png.Filter(png.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save filtered image
                png.Save(outputPath, new PngOptions());

                long filteredSize = new FileInfo(outputPath).Length;

                Console.WriteLine($"Original size: {originalSize} bytes");
                Console.WriteLine($"Filtered size: {filteredSize} bytes");

                if (filteredSize > originalSize * 1.5)
                {
                    Console.WriteLine("Warning: The filtered PNG size increased dramatically.");
                }
                else
                {
                    Console.WriteLine("The filtered PNG size is within acceptable range.");
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
 * 1. When a developer needs to verify that applying an emboss filter to a PNG image does not cause the file size to grow beyond an acceptable limit for web delivery.
 * 2. When a C# application must compare the original and filtered PNG sizes to prevent excessive bandwidth usage after image enhancement.
 * 3. When an image‑processing pipeline requires a safety check to ensure that convolution‑based embossing does not inflate PNG storage requirements beyond a set percentage.
 * 4. When a software solution must log and warn users if the filtered PNG exceeds 150 % of the original file size, helping maintain performance standards.
 * 5. When integrating Aspose.Imaging into a .NET project, developers need to programmatically assess the impact of emboss filtering on PNG compression efficiency before saving the output.
 */