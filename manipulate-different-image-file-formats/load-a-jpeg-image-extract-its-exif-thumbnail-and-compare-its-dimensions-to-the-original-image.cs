using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\thumbnail_output.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Original image dimensions
                int originalWidth = jpegImage.Width;
                int originalHeight = jpegImage.Height;
                Console.WriteLine($"Original image size: {originalWidth}x{originalHeight}");

                // Extract EXIF thumbnail
                RasterImage thumbnail = jpegImage.ExifData?.Thumbnail;

                if (thumbnail == null)
                {
                    Console.WriteLine("No EXIF thumbnail found in the image.");
                    return;
                }

                // Thumbnail dimensions
                int thumbWidth = thumbnail.Width;
                int thumbHeight = thumbnail.Height;
                Console.WriteLine($"Thumbnail size: {thumbWidth}x{thumbHeight}");

                // Compare dimensions
                if (thumbWidth == originalWidth && thumbHeight == originalHeight)
                {
                    Console.WriteLine("Thumbnail dimensions match the original image.");
                }
                else
                {
                    Console.WriteLine("Thumbnail dimensions differ from the original image.");
                }

                // Save thumbnail to output path
                using (var options = new JpegOptions())
                {
                    thumbnail.Save(outputPath, options);
                }

                Console.WriteLine($"Thumbnail saved to: {outputPath}");
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
 * 1. When building a photo‑gallery web app in C# you can use this code with Aspose.Imaging to load a JPEG, extract its EXIF thumbnail and verify that the thumbnail dimensions match the original image before displaying previews.
 * 2. When developing a mobile‑first e‑commerce platform you may need to confirm that the embedded EXIF thumbnail of product photos is correctly sized, so this snippet loads the JPEG, reads the thumbnail via Aspose.Imaging and compares its width and height to the full‑size image.
 * 3. When creating a batch‑processing tool that validates camera‑generated JPEG files, the code can detect mismatched EXIF thumbnail dimensions, helping to flag images with corrupted or missing thumbnail metadata.
 * 4. When generating PDF catalogs that include low‑resolution previews, you can extract the JPEG’s EXIF thumbnail with Aspose.Imaging, compare its size to the source image, and decide whether to use the thumbnail or generate a new one.
 * 5. When implementing a digital asset management system that indexes image metadata, this example shows how to load a JPEG, retrieve the EXIF thumbnail, and ensure its dimensions are consistent with the original, enabling reliable thumbnail caching.
 */