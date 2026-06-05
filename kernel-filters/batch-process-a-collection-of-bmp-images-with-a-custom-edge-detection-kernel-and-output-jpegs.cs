using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

                    double[,] kernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1, 8, -1 },
                        { -1, -1, -1 }
                    };
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 0, 1);
                    rasterImage.Filter(rasterImage.Bounds, filterOptions);

                    var jpegOptions = new JpegOptions();
                    rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to automatically enhance scanned engineering drawings stored as BMP files by highlighting edges before archiving them as compressed JPEGs.
 * 2. When a photo‑processing service must convert a large batch of legacy BMP product photos into web‑ready JPEGs while applying an edge‑detection filter to improve visual sharpness.
 * 3. When an automated quality‑control pipeline requires extracting contour information from BMP microscopy images and saving the results as JPEG thumbnails for quick review.
 * 4. When a desktop application needs to prepare BMP screenshots for inclusion in documentation by detecting edges and reducing file size through JPEG conversion.
 * 5. When a GIS tool processes BMP elevation maps, applies a custom convolution kernel to emphasize terrain ridges, and outputs the processed layers as JPEG tiles for faster rendering.
 */