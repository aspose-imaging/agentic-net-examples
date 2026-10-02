// HOW-TO: Apply Custom Sharpen Kernel to PNG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 9, -1 },
                    { -1, -1, -1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);
                var options = new PngOptions();
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
 * 1. When you need to programmatically enhance the details of a PNG photograph in a .NET application.
 * 2. When you want to replace a built‑in sharpening filter with a custom convolution matrix for precise image sharpening.
 * 3. When you are processing batches of PNG files on a server and must apply the same sharpen effect to each image automatically.
 * 4. When you need to integrate image sharpening into an automated workflow that also checks for file existence and creates output directories.
 * 5. When you are building a desktop tool that improves the clarity of screenshots before saving them as PNG files.
 */
