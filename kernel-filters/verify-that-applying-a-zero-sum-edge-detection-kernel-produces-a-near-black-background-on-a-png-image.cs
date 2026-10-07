// HOW-TO: Apply Zero Sum Edge Detection Kernel to PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] customKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                image.Filter(image.Bounds, filterOptions);

                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight edges in a PNG for computer‑vision preprocessing, you can apply a zero‑sum convolution kernel with Aspose.Imaging in C#.
 * 2. When preparing screenshots for documentation and want a near‑black background to emphasize details, this code applies an edge‑detect filter to the image.
 * 3. When building a C# application that automatically extracts outlines from PNG graphics for vectorization, the Laplacian kernel creates strong edge contrast.
 * 4. When performing quality‑control on scanned PNG images and need to detect defects by emphasizing edges, the convolution filter can reveal anomalies.
 * 5. When creating a custom thumbnail generator that accentuates object boundaries in PNG files, the zero‑sum kernel produces a high‑contrast result.
 */
