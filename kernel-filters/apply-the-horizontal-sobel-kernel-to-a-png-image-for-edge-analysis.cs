// HOW-TO: Apply Horizontal Sobel Edge Detection to PNG Image Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
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

            double[,] sobelKernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(sobelKernel));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight horizontal edges in a PNG photograph for computer‑vision preprocessing, you can apply a Sobel convolution filter in C#.
 * 2. When building a medical‑imaging tool that extracts vessel outlines from grayscale PNG scans, the horizontal Sobel kernel helps emphasize linear features.
 * 3. When creating a quality‑control system that detects scratches or seams on manufactured product images stored as PNG files, edge detection via the Sobel filter can flag defects.
 * 4. When developing a document‑analysis pipeline that isolates text baselines in scanned PNG pages, applying the Sobel operator simplifies subsequent OCR steps.
 * 5. When generating artistic edge‑enhanced versions of PNG graphics for stylized visual effects, the Sobel convolution provides a fast, programmable solution in .NET.
 */
