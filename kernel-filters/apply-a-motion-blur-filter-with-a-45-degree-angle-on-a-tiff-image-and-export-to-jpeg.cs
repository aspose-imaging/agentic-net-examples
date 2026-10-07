// HOW-TO: Apply 45 Degree Motion Blur to TIFF and Save as JPEG in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = ConvolutionFilter.GetBlurMotion(5, 45.0);
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                JpegOptions jpegOptions = new JpegOptions
                {
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
 * 1. When you need to add a directional motion‑blur effect to a high‑resolution TIFF scan before delivering it as a smaller JPEG for web preview.
 * 2. When converting legacy multi‑page TIFF documents to JPEG while applying a 45° blur to hide sensitive details.
 * 3. When creating stylized thumbnails from TIFF photographs by applying a motion blur and saving them in JPEG format for faster loading.
 * 4. When automating a batch process that prepares TIFF assets for mobile apps, adding a diagonal blur to reduce visual noise and outputting JPEG files.
 * 5. When integrating Aspose.Imaging in a C# service that receives TIFF uploads, applies a 5‑pixel motion blur at 45 degrees, and returns compressed JPEG images to clients.
 */
