// HOW-TO: Crop JPEG Image With Pixel Offsets And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageCropper
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input\\photo.jpg";
            string outputPath = "output\\cropped.png";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
                {
                    if (!rasterImage.IsCached)
                    {
                        rasterImage.CacheData();
                    }

                    // Offsets: left, right, top, bottom (in pixels)
                    int left = 10;
                    int right = 10;
                    int top = 10;
                    int bottom = 10;

                    rasterImage.Crop(left, right, top, bottom);
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to remove a uniform border from a JPEG photo before uploading it to a website, you can crop the image by specifying left, right, top, and bottom pixel offsets and then save the result as a PNG for loss‑less quality.
 * 2. When generating thumbnails for a gallery, you may want to trim unwanted edges from the original JPEG and output a PNG thumbnail that preserves transparency and sharpness.
 * 3. When processing scanned documents that contain extra margins, you can programmatically crop the JPEG scans using pixel offsets and store the cleaned‑up version as a PNG for archival.
 * 4. When preparing images for a mobile app that requires PNG assets, you can crop the source JPEG to focus on the central subject and convert it to PNG in a single C# routine.
 * 5. When automating a batch job that standardizes image dimensions, you can use the code to trim a fixed number of pixels from each side of JPEG files and save the uniformly cropped results as PNG files.
 */
