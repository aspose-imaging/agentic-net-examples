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
            string outputPath = "thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Retrieve the EXIF thumbnail (RasterImage)
                RasterImage thumbnail = jpegImage.ExifData?.Thumbnail;
                if (thumbnail == null)
                {
                    Console.Error.WriteLine("No EXIF thumbnail found in the image.");
                    return;
                }

                // Save the thumbnail as a separate JPEG file
                var jpegOptions = new JpegOptions();
                thumbnail.Save(outputPath, jpegOptions);
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
 * 1. When a photo‑sharing web app needs to quickly display preview images without re‑encoding the original JPEG, a developer can extract the embedded EXIF thumbnail and save it as a separate JPEG file.
 * 2. When a digital asset management system imports large batches of photos and wants to generate low‑resolution previews for its UI, the code can pull the EXIF thumbnail to avoid costly full‑size image processing.
 * 3. When a mobile app syncs images to the cloud and must upload a small preview for bandwidth‑limited connections, extracting the EXIF thumbnail provides an instant thumbnail file.
 * 4. When a desktop photo organizer wants to create a thumbnail cache for fast folder browsing, using the EXIF thumbnail extraction saves time compared to resizing the original image.
 * 5. When a forensic analysis tool needs to verify that an image contains an embedded thumbnail before further processing, the code can read the EXIF thumbnail and store it as a separate JPEG for inspection.
 */