// HOW-TO: Apply Median Then Sharpen Filter to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply median filter with size 3
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                // Apply sharpen filter
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                // Save the processed image as JPEG
                image.Save(outputPath, new JpegOptions());
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
 * 1. When you need to reduce noise in a scanned JPEG photo before enhancing its edges for a clearer presentation.
 * 2. When preparing product images for an e‑commerce site, you can clean up grainy JPEGs and sharpen details to improve visual appeal.
 * 3. When processing medical imaging scans saved as JPEG, applying median filtering followed by sharpening helps highlight anatomical structures while suppressing artifacts.
 * 4. When automating batch image cleanup in a C# application, this code removes speckles and accentuates edges before saving the optimized JPEGs.
 * 5. When creating thumbnails for a gallery, you can first denoise the source JPEG and then sharpen it to retain crispness at smaller sizes.
 */
