using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                double sum = 0;
                foreach (double v in kernel)
                {
                    sum += v;
                }

                const double tolerance = 1e-6;
                if (Math.Abs(sum - 1.0) > tolerance)
                {
                    Console.Error.WriteLine("Kernel coefficients do not sum to 1. Filter not applied.");
                    return;
                }

                var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);
                rasterImage.Filter(rasterImage.Bounds, options);
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer wants to apply a sharpening convolution filter to a PNG image using Aspose.Imaging for .NET but must ensure the custom kernel is normalized so the image brightness remains unchanged.
 * 2. When processing scanned documents in C# and applying edge‑enhancement filters, validating that the sum of the kernel coefficients equals one prevents unintended darkening or brightening of the output PDF or PNG.
 * 3. When building an automated image‑processing pipeline that reads raster images, applies user‑defined convolution kernels, and saves the result, checking the kernel sum avoids runtime errors and preserves color balance.
 * 4. When integrating custom image filters into a Windows desktop application, the code ensures that any 3×3 kernel supplied by the UI is correctly normalized before the Aspose.Imaging Filter method is called.
 * 5. When performing batch conversion of JPEG files to PNG with a custom filter, the tolerance check guarantees that only properly normalized kernels are applied, maintaining consistent visual quality across all output images.
 */