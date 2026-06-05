using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\sample.png";
        string outputPath = "output\\filtered.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[5, 5]
                {
                    { 0, 0, -1, 0, 0 },
                    { 0, -1, -2, -1, 0 },
                    { -1, -2, 16, -2, -1 },
                    { 0, -1, -2, -1, 0 },
                    { 0, 0, -1, 0, 0 }
                };

                var options = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, options);
                raster.Save(outputPath);
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
 * 1. When a developer wants to enhance the edges of a PNG photograph for a product catalog by applying a custom 5x5 sharpening convolution filter using Aspose.Imaging for .NET.
 * 2. When a C# application needs to preprocess scanned PDF pages saved as JPEG images to improve text readability before OCR by applying a custom kernel.
 * 3. When a game developer must generate a stylized outline effect on sprite sheets (BMP format) to highlight characters in a 2‑D game using a 5x5 convolution filter.
 * 4. When an automated image‑processing pipeline processes satellite TIFF images and requires a custom high‑pass filter to accentuate terrain features.
 * 5. When a medical imaging tool needs to sharpen low‑contrast DICOM slices exported as PNG files to aid radiologists in detecting subtle anomalies.
 */