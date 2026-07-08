using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply edge detection using a Sobel kernel
                double[,] edgeKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(edgeKernel));

                // Apply sharpen filter
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save as JPEG
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When a developer needs to preprocess a PNG screenshot by blurring, detecting edges, and sharpening before converting it to a high‑quality JPEG for inclusion in a web‑based report.
 * 2. When an e‑commerce platform must automatically enhance product photos—applying Gaussian blur to reduce noise, Sobel edge detection to highlight contours, and sharpening—then save them as JPEG thumbnails.
 * 3. When a medical imaging application requires batch conversion of PNG scans, applying a sequence of filters to improve visual clarity before archiving the results as JPEG files.
 * 4. When a game developer wants to generate stylized JPEG textures from PNG assets by chaining blur, edge detection, and sharpen filters using Aspose.Imaging in C#.
 * 5. When a digital marketing tool needs to transform user‑uploaded PNG logos with a blur‑edge‑sharpen pipeline and output optimized JPEG images for email campaigns.
 */