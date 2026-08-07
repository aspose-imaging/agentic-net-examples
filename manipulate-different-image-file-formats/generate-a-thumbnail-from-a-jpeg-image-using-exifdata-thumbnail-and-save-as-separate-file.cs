using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
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

        try
        {
            // Load the JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Get the EXIF thumbnail (RasterImage)
                RasterImage thumb = jpegImage.ExifData.Thumbnail;

                if (thumb == null)
                {
                    Console.Error.WriteLine("No thumbnail found in EXIF data.");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the thumbnail as a separate file
                using (thumb)
                {
                    thumb.Save(outputPath);
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
 * 1. When building a photo‑gallery web application that needs fast preview images, a developer can extract the JPEG’s embedded EXIF thumbnail and save it as a separate JPEG file using Aspose.Imaging for .NET.
 * 2. When creating a desktop photo organizer that generates folder thumbnails for Windows Explorer, the code can read the JPEG’s ExifData.Thumbnail and write a small thumbnail.jpg to improve folder preview performance.
 * 3. When developing a digital asset management system that indexes images and stores low‑resolution previews for search results, extracting the EXIF thumbnail with C# and Aspose.Imaging provides an efficient way to generate those previews.
 * 4. When implementing a batch‑processing script that validates image metadata and needs to archive the original thumbnail for compliance or forensic purposes, this snippet saves the embedded raster thumbnail as a separate file.
 * 5. When optimizing a mobile app’s image‑upload workflow by sending only the EXIF thumbnail to the server for quick visual confirmation, the developer can use this code to extract and save the thumbnail before uploading.
 */