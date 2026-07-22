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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply predefined sharpen filter
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Apply custom edge‑detection kernel
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the result as PNG
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
 * 1. When a developer needs to enhance the details of a PNG screenshot by sharpening it and then highlighting edges for a technical documentation illustration.
 * 2. When an e‑commerce platform automatically processes product photos in C# to make features stand out by applying a sharpen filter followed by a custom edge‑detection convolution before saving them as PNG files.
 * 3. When a medical imaging application preprocesses scanned PNG slides to improve contrast and detect tissue boundaries using Aspose.Imaging’s SharpenFilterOptions and a 3×3 edge‑detection kernel.
 * 4. When a game developer prepares UI assets by programmatically sharpening PNG icons and extracting their outlines to create crisp hover‑state graphics.
 * 5. When a content‑management system batch‑processes uploaded PNG images to improve visual clarity and generate edge‑enhanced thumbnails using C# and Aspose.Imaging filters.
 */