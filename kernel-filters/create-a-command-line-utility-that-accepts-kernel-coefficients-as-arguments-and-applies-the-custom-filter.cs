using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[] flatKernel = args.Select(a => double.Parse(a)).ToArray();
            int length = flatKernel.Length;
            int size = (int)Math.Sqrt(length);
            if (size * size != length)
            {
                Console.Error.WriteLine("Kernel size must be a perfect square.");
                return;
            }

            double[,] kernel = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] = flatKernel[i * size + j];
                }
            }

            double factor = 1.0;
            int offset = 0;

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, factor, offset);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
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
 * 1. When a developer needs to sharpen PNG images in an automated build pipeline by passing a 3×3 sharpening kernel to a C# command‑line tool that uses Aspose.Imaging’s ConvolutionFilterOptions.
 * 2. When a developer wants to detect edges in scanned documents before OCR by supplying a Sobel kernel to the utility, which loads the input file, applies the filter, and saves the result as a PNG.
 * 3. When a developer must reduce high‑frequency noise in medical imaging data by providing a Gaussian blur kernel to the command‑line program that processes raster images with Aspose.Imaging.
 * 4. When a developer creates a custom emboss effect for product photos by entering a user‑defined kernel matrix as arguments to the tool that applies the convolution filter and writes the output to an output folder.
 * 5. When a developer integrates the utility into a batch script to apply different user‑specified filters to multiple PNG files, enabling dynamic image preprocessing without writing additional C# code.
 */