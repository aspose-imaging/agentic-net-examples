// HOW-TO: Apply Custom 3x3 Edge Detection Kernel to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

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
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                var options = new ConvolutionFilterOptions(customKernel);
                image.Filter(image.Bounds, options);
                image.Save(outputPath);
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
 * 1. When you need to highlight edges in a photograph before performing object detection, you can use this C# code to apply a custom 3×3 edge‑detection kernel to a JPEG image.
 * 2. When preparing scanned documents for OCR, applying the zero‑sum convolution filter helps sharpen text boundaries, improving recognition accuracy.
 * 3. When creating a visual effect for a web gallery, you can programmatically enhance outlines of PNG or JPEG images using the custom kernel in Aspose.Imaging.
 * 4. When building a desktop application that automatically flags defective parts in product photos, the edge‑detection filter isolates contours for further analysis.
 * 5. When converting a batch of images to a stylized sketch‑like appearance, the code demonstrates how to apply the kernel to each file and save the results with Aspose.Imaging.
 */
