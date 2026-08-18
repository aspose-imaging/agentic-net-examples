// HOW-TO: Create a WebP Thumbnail From a TIFF Image Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output/thumbnail.webp";

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
                TiffImage tiff = image as TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("Input is not a TIFF image.");
                    return;
                }

                RasterImage raster = (RasterImage)image;

                int maxThumbWidth = 150;
                int maxThumbHeight = 150;
                double ratio = Math.Min((double)maxThumbWidth / raster.Width, (double)maxThumbHeight / raster.Height);
                int thumbWidth = (int)(raster.Width * ratio);
                int thumbHeight = (int)(raster.Height * ratio);

                raster.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                var webpOptions = new WebPOptions();
                raster.Save(outputPath, webpOptions);
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
 * 1. When you need to generate small preview images for high‑resolution TIFF files to display quickly on web pages.
 * 2. When you want to convert embedded TIFF thumbnails to the modern WebP format to reduce bandwidth.
 * 3. When a document management system stores scans as TIFF and requires lightweight WebP thumbnails for file browsers.
 * 4. When building a C# service that extracts and resizes TIFF images for mobile app thumbnails.
 * 5. When automating batch processing of TIFF archives to create uniform 150 × 150 WebP previews for catalog listings.
 */
