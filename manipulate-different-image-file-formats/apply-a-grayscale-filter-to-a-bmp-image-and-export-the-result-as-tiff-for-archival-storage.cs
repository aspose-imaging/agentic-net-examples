// HOW-TO: Convert BMP to Grayscale TIFF for Archival Storage in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "sample.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }
                raster.Grayscale();

                using (TiffOptions options = new TiffOptions(TiffExpectedFormat.Default))
                {
                    raster.Save(outputPath, options);
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
 * 1. When you need to archive legacy BMP scans as lossless grayscale TIFF files to reduce file size while preserving image quality.
 * 2. When a document management system requires all incoming bitmap images to be converted to a standard grayscale TIFF format for consistent indexing.
 * 3. When preparing medical or engineering drawings for long‑term storage, converting them from BMP to grayscale TIFF ensures compatibility with archival standards.
 * 4. When automating a batch process that reads BMP files, applies a grayscale filter, and saves them as TIFF using Aspose.Imaging in a .NET application.
 * 5. When you must ensure the BMP image data is cached before manipulation to avoid memory issues during grayscale conversion and TIFF export.
 */
