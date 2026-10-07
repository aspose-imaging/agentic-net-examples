// HOW-TO: Extract EXIF Thumbnail From JPEG And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/thumbnail.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                var thumbRaster = jpegImage.ExifData?.Thumbnail;
                if (thumbRaster == null)
                {
                    Console.Error.WriteLine("No EXIF thumbnail found.");
                    return;
                }

                using (thumbRaster)
                {
                    var pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    thumbRaster.Save(outputPath, pngOptions);
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
 * 1. When building a photo‑gallery app that shows quick previews, you can extract the embedded EXIF thumbnail from uploaded JPEGs and store it as a lightweight PNG for faster loading.
 * 2. When creating a digital asset management system that indexes images, extracting the EXIF thumbnail allows you to generate low‑resolution previews without decoding the full‑size JPEG.
 * 3. When developing a mobile‑friendly API that returns image thumbnails, you can use this code to read the JPEG’s EXIF thumbnail and deliver it as a PNG to ensure consistent format support.
 * 4. When migrating legacy photo archives, extracting and saving EXIF thumbnails as separate PNG files helps preserve original preview data while converting the main images to new formats.
 * 5. When implementing a backup solution that needs to verify image integrity, extracting the EXIF thumbnail and comparing it to a stored PNG can quickly detect corrupted JPEG files.
 */
