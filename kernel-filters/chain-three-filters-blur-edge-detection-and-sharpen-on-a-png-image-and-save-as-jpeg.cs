// HOW-TO: Apply Blur, Edge Detection, and Sharpen to PNG and Save as JPEG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Blur
                var blurOptions = new GaussianBlurFilterOptions();
                image.Filter(image.Bounds, blurOptions);

                // Edge detection with custom kernel
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };
                var edgeOptions = new ConvolutionFilterOptions(edgeKernel);
                image.Filter(image.Bounds, edgeOptions);

                // Sharpen
                var sharpenOptions = new SharpenFilterOptions();
                image.Filter(image.Bounds, sharpenOptions);

                // Save as JPEG
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to preprocess a PNG screenshot by blurring, highlighting edges, and sharpening before converting it to a JPEG for web thumbnails.
 * 2. When generating product catalog images where a PNG logo must be softened, its contours emphasized, and then sharpened before saving as a compressed JPEG.
 * 3. When preparing scanned documents in PNG format for OCR, applying blur to reduce noise, edge detection to define text boundaries, and sharpening to improve readability before converting to JPEG.
 * 4. When creating artistic filter effects in a C# desktop app, chaining Gaussian blur, custom edge detection, and sharpen filters on a PNG and exporting the result as a JPEG.
 * 5. When automating batch image processing in .NET, applying a sequence of filters to PNG files and saving the final output as JPEG to reduce file size for email attachments.
 */
