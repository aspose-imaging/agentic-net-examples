using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/template.png";
            string outputPath = "output/result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { 0, 1, 0 },
                    { 1, 4, 1 },
                    { 0, 1, 0 }
                };

                double sum = 0;
                foreach (double v in kernel) sum += v;
                if (sum != 0)
                {
                    for (int i = 0; i < kernel.GetLength(0); i++)
                    {
                        for (int j = 0; j < kernel.GetLength(1); j++)
                        {
                            kernel[i, j] /= sum;
                        }
                    }
                }

                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);
                raster.Filter(raster.Bounds, filterOptions);

                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to sharpen a PNG template by applying a custom normalized convolution kernel before embedding it in a web page, this C# Aspose.Imaging code provides a quick solution.
 * 2. When an e‑commerce platform wants to enhance product label images by applying a consistent blur‑sharpen filter to PNG assets during batch processing, the code can be used to load, filter, and save each image.
 * 3. When a medical imaging application must preprocess PNG scans with a custom edge‑enhancement kernel to improve visual clarity before analysis, the example demonstrates how to normalize the kernel and apply it with Aspose.Imaging.
 * 4. When a game developer wants to dynamically adjust the visual style of UI icons stored as PNG files by applying a custom convolution filter at runtime, this snippet shows the necessary C# operations.
 * 5. When an automated reporting tool generates PNG charts and needs to apply a uniform smoothing filter to reduce noise before exporting the final image, the code illustrates the complete load‑filter‑save workflow.
 */