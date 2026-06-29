using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output\\thumbnail.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
            {
                // Extract the EXIF thumbnail
                RasterImage thumbnail = jpeg.ExifData?.Thumbnail;
                if (thumbnail == null)
                {
                    Console.Error.WriteLine("No EXIF thumbnail found in the image.");
                    return;
                }

                // Save the thumbnail as a PNG file
                var pngOptions = new PngOptions();
                thumbnail.Save(outputPath, pngOptions);
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
 * 1. When a photo‑sharing app needs to quickly display preview images, a developer can load a JPEG, extract its embedded EXIF thumbnail, and save it as a lightweight PNG using Aspose.Imaging for .NET.
 * 2. When a digital asset management system must generate catalog thumbnails without re‑encoding the full‑size image, the code can read the JPEG’s EXIF thumbnail and output it as a PNG file.
 * 3. When a web service processes user‑uploaded photos and wants to store a small preview for faster page loads, the developer can extract the EXIF thumbnail from the JPEG and save it as a PNG with C#.
 * 4. When an e‑commerce platform wants to create product image previews from high‑resolution JPEGs while preserving original metadata, the code extracts the EXIF thumbnail and converts it to PNG for display.
 * 5. When a desktop utility needs to batch‑convert embedded EXIF thumbnails in a collection of JPEG files to separate PNG files for archival or printing purposes, this Aspose.Imaging snippet handles the extraction and saving.
 */