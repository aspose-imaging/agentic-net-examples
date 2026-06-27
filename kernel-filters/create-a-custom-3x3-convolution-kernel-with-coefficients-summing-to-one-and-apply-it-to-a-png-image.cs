using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

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

                double[,] kernel = new double[3, 3]
                {
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                };

                var filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

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
 * 1. When a developer wants to reduce noise in a PNG screenshot by applying a simple averaging filter using a 3x3 convolution kernel in C# with Aspose.Imaging.
 * 2. When a web application needs to generate a softened thumbnail of a user‑uploaded PNG image by applying a normalized convolution filter before saving it.
 * 3. When an automated batch process must uniformly blur multiple PNG assets for privacy compliance, using a custom kernel whose coefficients sum to one.
 * 4. When a desktop utility has to smooth out color gradients in a scanned PNG diagram to improve visual quality without changing the image dimensions.
 * 5. When a C# service is required to apply a lightweight low‑pass filter to PNG graphics before embedding them in a PDF report generated with Aspose.Imaging.
 */