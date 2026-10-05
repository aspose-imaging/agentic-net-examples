// HOW-TO: Batch Apply Blur Filter to PNG Images and Save as JPEG in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            double[,] blurKernel = new double[,]
            {
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 }
            };

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(blurKernel));

                    JpegOptions jpegOptions = new JpegOptions();
                    raster.Save(outputPath, jpegOptions);
                }
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
 * 1. When you need to automatically blur a collection of PNG assets before publishing them as compressed JPEGs for a web gallery.
 * 2. When you want to preprocess scanned PNG documents with a uniform box blur to reduce noise before converting them to JPEG for archival storage.
 * 3. When a photo‑editing tool must apply the same convolution filter to every PNG in a folder and output JPEGs for faster loading on mobile devices.
 * 4. When an e‑commerce platform requires batch conversion of product PNG images with a subtle blur effect to meet branding guidelines while delivering JPEG thumbnails.
 * 5. When a CI/CD pipeline should validate image quality by applying a predefined blur kernel to PNG test assets and generate JPEG results for visual regression testing.
 */
