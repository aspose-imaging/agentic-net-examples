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
        string inputPath = "sample.jpg";
        string outputPath = "thumbnail.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Get EXIF thumbnail
                var thumbnail = jpegImage.ExifData?.Thumbnail;
                if (thumbnail == null)
                {
                    Console.Error.WriteLine("No EXIF thumbnail found in the image.");
                    return;
                }

                // Save thumbnail as PNG
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
 * 1. When a photo‑sharing web app needs to display a small preview of a high‑resolution JPEG without loading the full image, a developer can extract the embedded EXIF thumbnail and save it as a PNG for fast rendering.
 * 2. When a digital asset management system imports user‑uploaded photos and wants to generate lightweight thumbnails for catalog browsing, the code can read the JPEG’s EXIF thumbnail and store it as a PNG file.
 * 3. When a mobile app synchronizes images to a server but must conserve bandwidth, a developer can use this snippet to pull the EXIF thumbnail from each JPEG and upload the smaller PNG instead of the original file.
 * 4. When an e‑commerce platform needs to create product image previews from supplier‑provided JPEGs that already contain EXIF thumbnails, the code allows direct extraction and conversion to PNG for consistent thumbnail format.
 * 5. When a desktop utility audits a collection of photographs for missing thumbnails, a developer can run this routine to extract any existing EXIF thumbnail from each JPEG and save it as a PNG for further analysis.
 */