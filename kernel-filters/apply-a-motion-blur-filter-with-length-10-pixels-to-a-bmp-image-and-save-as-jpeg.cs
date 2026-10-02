// HOW-TO: Apply 10 Pixel Motion Blur to BMP and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.bmp";
        string outputPath = "Output\\result.jpg";

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

                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(10, 0);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                raster.Filter(raster.Bounds, filterOptions);

                JpegOptions jpegOptions = new JpegOptions();
                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to add a realistic motion effect to a scanned BMP photograph before compressing it to JPEG for web publishing.
 * 2. When you want to preprocess BMP assets in a game pipeline by blurring motion to reduce visual noise and then convert them to JPEG for faster loading.
 * 3. When an automated batch job must apply a 10‑pixel motion blur to a collection of BMP images and store the results as JPEG files for archival.
 * 4. When integrating Aspose.Imaging into a C# service that receives BMP uploads, applies motion blur for privacy or artistic purposes, and returns JPEG thumbnails.
 * 5. When converting high‑resolution BMP scans to JPEG while adding a motion blur filter to simulate camera movement in a photo‑editing application.
 */
