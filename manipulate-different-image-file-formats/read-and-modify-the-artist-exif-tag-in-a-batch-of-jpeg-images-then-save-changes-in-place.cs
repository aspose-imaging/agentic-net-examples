using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing JPEG files
        string inputDirectory = @"C:\Images\Input";

        try
        {
            // Get all JPEG files in the directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            foreach (string inputPath in jpegFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists (same as input directory for in‑place save)
                Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

                // Load the JPEG image
                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    // Access JPEG EXIF data
                    JpegExifData jpegExif = image.ExifData as JpegExifData;
                    if (jpegExif != null)
                    {
                        // Modify the Artist tag
                        jpegExif.Artist = "New Artist";
                    }

                    // Save changes back to the same file (in‑place)
                    image.Save(inputPath);
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
 * 1. When a photographer uses Aspose.Imaging for .NET to embed or update the Artist EXIF tag across a folder of JPEG images before publishing them online.
 * 2. When a digital asset management system processes a batch of JPEG files in C# and standardizes the Artist metadata to enable consistent search and filtering.
 * 3. When a web application automatically adds the photographer’s name to existing JPEG files during a bulk upload, using Aspose.Imaging to modify the EXIF Artist tag in place.
 * 4. When a company migrates legacy product images and must replace outdated Artist information with the current brand name across thousands of JPEG files using C# batch processing.
 * 5. When a photo‑editing workflow requires batch correction of the Artist EXIF tag after renaming files, ensuring the metadata matches the new organization without creating new files.
 */