// HOW-TO: Compare Sobel Custom Kernel Edge Detection with Emboss3x3 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string sobelOutputPath = "output\\sobel.png";
        string embossOutputPath = "output\\emboss.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(sobelOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(embossOutputPath));

            // Apply Sobel-like custom kernel
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel));

                PngOptions sobelOptions = new PngOptions();
                raster.Save(sobelOutputPath, sobelOptions);
            }

            // Apply Emboss3x3 kernel
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                PngOptions embossOptions = new PngOptions();
                raster.Save(embossOutputPath, embossOptions);
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
 * 1. When you need to highlight edges in a PNG photograph for computer‑vision preprocessing, you can apply a Sobel‑like convolution filter using Aspose.Imaging in C#.
 * 2. When you want to generate a stylized emboss effect for product thumbnails and compare it against edge detection results, you can use the built‑in Emboss3x3 kernel with Aspose.Imaging.
 * 3. When evaluating which convolution kernel provides clearer contours for OCR preprocessing, you can run both Sobel and Emboss filters on the same image and save the outputs as separate PNG files.
 * 4. When building an automated quality‑control pipeline that flags images with weak edge contrast, you can compare the Sobel‑derived edge map to an emboss‑based version to decide if enhancement is required.
 * 5. When creating side‑by‑side visual comparisons for a UI that lets users choose their preferred edge‑enhancement style, you can generate Sobel and Emboss PNGs programmatically with Aspose.Imaging in .NET.
 */
