using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

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
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 0.0, 1);
                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer wants to highlight horizontal edges in a PNG photograph for a medical imaging analysis tool using C# and Aspose.Imaging's convolution filter.
 * 2. When building an automated quality‑inspection system that detects cracks or seams in manufactured parts by applying a Sobel horizontal kernel to raster images.
 * 3. When creating a web service that converts uploaded images to edge‑enhanced versions for artistic filters, requiring C# code that loads the image, runs a 3×3 Sobel filter, and saves the result as PNG.
 * 4. When preprocessing satellite or aerial imagery to emphasize terrain features such as ridgelines before feeding the data into a machine‑learning model, using Aspose.Imaging's ConvolutionFilterOptions.
 * 5. When developing a desktop application that extracts text line boundaries from scanned documents by detecting horizontal edges in the scanned PNG files with a Sobel filter in .NET.
 */