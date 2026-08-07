using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output_emboss.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var embossKernel = ConvolutionFilter.Emboss3x3;
                var filterOptions = new ConvolutionFilterOptions(embossKernel);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
            }

            long originalSize = new FileInfo(inputPath).Length;
            long filteredSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Filtered size: {filteredSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to apply an emboss effect to a PNG image and verify that the resulting file size does not grow excessively for web delivery.
 * 2. When a developer needs to automate quality checks on batch‑processed PNG assets to ensure that applying a convolution emboss filter does not cause storage bloat.
 * 3. When a developer integrates Aspose.Imaging into a C# application to compare original and filtered PNG sizes before uploading them to a content‑delivery network.
 * 4. When a developer builds a CI pipeline that runs image processing tests, using the code to confirm that emboss filtering keeps PNG file size within acceptable limits.
 * 5. When a developer creates a desktop tool that lets users preview an emboss effect on PNGs while monitoring the size difference to maintain performance constraints.
 */