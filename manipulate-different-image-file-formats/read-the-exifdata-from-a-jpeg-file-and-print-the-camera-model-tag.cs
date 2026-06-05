using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\sample.jpg";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data
                ExifData exifData = image.ExifData;

                if (exifData != null)
                {
                    // Cast to JPEG-specific EXIF data to get the Model property
                    JpegExifData jpegExif = exifData as JpegExifData;
                    if (jpegExif != null)
                    {
                        // Print the camera model tag
                        Console.WriteLine($"Camera model: {jpegExif.Model}");
                    }
                    else
                    {
                        Console.WriteLine("No JPEG EXIF data available.");
                    }
                }
                else
                {
                    Console.WriteLine("No EXIF data found in the image.");
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
 * 1. When building a photo gallery web app in C# that groups images by the camera model, a developer can use this code to extract the Model tag from JPEG EXIF data.
 * 2. When generating a digital asset report that lists the equipment used for each photo, the code helps read the camera model from JPEG files using Aspose.Imaging.
 * 3. When validating that uploaded images were captured with an approved device, a C# service can read the EXIF Model tag to enforce compliance.
 * 4. When creating a desktop utility that renames JPEG files based on the camera model, this snippet provides the necessary EXIF extraction in .NET.
 * 5. When performing forensic analysis of image metadata to trace the source of a JPEG, the code enables quick retrieval of the camera model tag via Aspose.Imaging.
 */