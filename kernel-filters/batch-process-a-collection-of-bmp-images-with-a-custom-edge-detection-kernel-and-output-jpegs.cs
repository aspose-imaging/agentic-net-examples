// HOW-TO: Batch Convert BMP Images to JPEG with Edge Detection in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string extension = Path.GetExtension(inputPath);
                if (!string.Equals(extension, ".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(Path.GetFileName(inputPath), ".jpg"));
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Not a raster image: {inputPath}");
                        continue;
                    }

                    double[,] customKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                    raster.Filter(new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height), filterOptions);

                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.Quality = 90;
                        raster.Save(outputPath, jpegOptions);
                    }
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
 * 1. When you need to automatically apply an edge‑detect filter to a folder of legacy BMP files and save the results as smaller JPEGs for web publishing.
 * 2. When a desktop application must process scanned documents in BMP format, highlight their outlines, and store the processed images in a JPEG archive.
 * 3. When a batch job has to convert a large collection of BMP graphics from a manufacturing system into JPEGs while enhancing edges for visual inspection.
 * 4. When you want to integrate custom convolution kernels into an automated pipeline that reads BMP files, performs edge detection, and outputs JPEGs for downstream AI analysis.
 * 5. When a migration script must replace BMP assets with JPEG equivalents and improve their visual sharpness by applying an edge detection filter during conversion.
 */
