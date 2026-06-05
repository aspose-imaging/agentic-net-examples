using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Apply edge detection via convolution kernel
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel));

                // Apply sharpen filter
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save as JPEG
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When a developer needs to preprocess a PNG screenshot by smoothing, highlighting edges, and enhancing details before storing it as a high‑quality JPEG for web display.
 * 2. When an application must convert scanned PNG documents into JPEG thumbnails while applying blur to reduce noise, edge detection to emphasize text boundaries, and sharpening to improve readability.
 * 3. When a photo‑editing tool automates batch processing of PNG assets, applying a Gaussian blur, a convolution edge filter, and a sharpen filter in C# before exporting the results as compressed JPEG files.
 * 4. When a machine‑learning pipeline requires PNG images to be normalized with blur, edge extraction, and sharpening steps prior to saving them as JPEGs for model training.
 * 5. When a mobile backend service receives PNG uploads, needs to enhance visual quality by chaining blur, edge detection, and sharpen filters, and then stores the processed images as JPEGs to save bandwidth.
 */