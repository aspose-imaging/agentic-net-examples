// HOW-TO: Apply Emboss Filter to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output_emboss.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                double[,] embossKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                raster.Filter(raster.Bounds, filterOptions);

                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                raster.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to add a realistic embossed effect to user‑uploaded photos and save the result as a high‑quality JPEG.
 * 2. When an image‑processing pipeline must transform raster images with a custom convolution kernel before publishing them to a web gallery.
 * 3. When a WPF desktop application wants to let users preview an emboss effect on a bitmap in real time using Aspose.Imaging.
 * 4. When a batch job has to process a directory of images, apply the emboss filter, and output JPEG files with a specific compression quality.
 * 5. When a programmer wants to experiment with custom convolution kernels without writing low‑level pixel loops, leveraging Aspose.Imaging’s FilterOptions.
 */
