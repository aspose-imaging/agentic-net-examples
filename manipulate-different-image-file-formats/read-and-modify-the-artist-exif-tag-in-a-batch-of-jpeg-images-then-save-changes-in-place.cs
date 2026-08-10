// HOW-TO: Update Artist EXIF Tag in Multiple JPEGs Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of JPEG files to process
            string[] inputFiles = new string[]
            {
                @"C:\Images\photo1.jpg",
                @"C:\Images\photo2.jpg",
                @"C:\Images\photo3.jpg"
            };

            // New value for the Artist EXIF tag
            string newArtist = "John Doe";

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists (same as input directory)
                string outputDir = Path.GetDirectoryName(inputPath);
                Directory.CreateDirectory(outputDir);

                // Load the JPEG image
                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    // Access EXIF data and set the Artist tag
                    JpegExifData exif = image.ExifData;
                    if (exif != null)
                    {
                        exif.Artist = newArtist;
                    }

                    // Save changes back to the original file (in-place)
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
 * 1. When a photographer wants to embed their name into a batch of JPEG photos before uploading them to a portfolio site.
 * 2. When a digital asset management system needs to standardize the Artist metadata across existing images for proper attribution.
 * 3. When a legal compliance script must add or correct the creator information in JPEG files stored on a server.
 * 4. When a photo‑sharing application requires updating the EXIF Artist tag of user‑uploaded images without creating new files.
 * 5. When a batch‑processing tool needs to modify JPEG metadata in place to keep file paths unchanged while preserving image quality.
 */
