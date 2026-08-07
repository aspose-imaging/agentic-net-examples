using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output_normalized.png";

        try
        {
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
                    { -1, -1, -1 },
                    { -1,  9, -1 },
                    { -1, -1, -1 }
                };

                double sum = 0;
                foreach (double v in kernel)
                {
                    sum += v;
                }

                if (Math.Abs(sum) < 1e-6)
                {
                    sum = 1;
                }

                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        kernel[i, j] /= sum;
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 0.0, 1);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
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
 * 1. When a developer needs to sharpen PNG photographs in a .NET web service while preserving overall brightness, they can apply the normalized convolution kernel shown above using Aspose.Imaging’s RasterImage.Filter method.
 * 2. When building a desktop batch‑processing tool that applies a custom sharpening filter to multiple image formats (PNG, JPEG, BMP) and must avoid darkening or over‑brightening the output, the code demonstrates how to normalize the kernel before convolution.
 * 3. When integrating image enhancement into an automated document‑scanning pipeline, the normalized kernel ensures that the sharpened scanned pages retain consistent luminance across varying input qualities.
 * 4. When creating a real‑time photo‑editing feature in a C# Windows Forms application, developers can use the kernel normalization technique to keep the visual appearance stable after applying high‑pass filters.
 * 5. When developing a server‑side image‑processing API that receives raw raster data and returns a sharpened image, normalizing the convolution matrix prevents unexpected brightness shifts and produces predictable results for clients.
 */