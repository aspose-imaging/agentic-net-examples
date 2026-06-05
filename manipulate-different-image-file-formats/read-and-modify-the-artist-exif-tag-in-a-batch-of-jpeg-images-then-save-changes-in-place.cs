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
            string[] inputPaths = new string[]
            {
                @"c:\images\photo1.jpg",
                @"c:\images\photo2.jpg",
                @"c:\images\photo3.jpg"
            };

            // New Artist value to set
            string newArtist = "John Doe";

            foreach (string inputPath in inputPaths)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Output path is the same as input path (in‑place modification)
                string outputPath = inputPath;

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the JPEG image
                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    // Access EXIF data
                    JpegExifData jpegExif = image.ExifData as JpegExifData;
                    if (jpegExif != null)
                    {
                        // Set the Artist tag
                        jpegExif.Artist = newArtist;
                    }

                    // Save changes back to the same file
                    image.Save(outputPath);
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
 * 1. When a photographer wants to embed or update the copyright holder’s name across dozens of JPEG files before publishing them online using C# and Aspose.Imaging.
 * 2. When a digital asset management system needs to standardize the Artist EXIF tag for a batch of product photos imported from multiple sources.
 * 3. When a mobile app backend processes user‑uploaded JPEG images and must replace the original artist metadata with the logged‑in user’s name for compliance.
 * 4. When a legal team requires the same photographer attribution to be added to all evidence images stored as JPEGs in a case folder, performing an in‑place modification with Aspose.Imaging.
 * 5. When a batch script is needed to correct misspelled artist information in existing JPEG files without creating new copies, using C# and Aspose.Imaging.
 */