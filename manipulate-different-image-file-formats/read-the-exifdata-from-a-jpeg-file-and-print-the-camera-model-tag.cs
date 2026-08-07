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
            // Hardcoded input path
            string inputPath = "sample.jpg";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access JPEG-specific EXIF data
                JpegExifData jpegExif = image.ExifData as JpegExifData;
                if (jpegExif != null)
                {
                    // Print the camera model tag
                    Console.WriteLine($"Camera model: {jpegExif.Model}");
                }
                else
                {
                    Console.WriteLine("No JPEG EXIF data found.");
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When building a photo gallery web app that displays camera information alongside each JPEG thumbnail, a developer can use this C# code with Aspose.Imaging to extract the camera model from the EXIF data.
 * 2. When generating a usage report for a photography studio, the snippet reads the Model tag from JPEG files to identify which camera captured each image.
 * 3. When validating image metadata before archiving digital assets, a developer can run this code to ensure that each JPEG contains a valid camera model EXIF tag.
 * 4. When creating a C# desktop tool that sorts JPEG images into folders based on the camera model, the program reads the Model property from the JPEG EXIF data using Aspose.Imaging.
 * 5. When troubleshooting inconsistencies in a batch of product photos, a developer can quickly print the camera model from each JPEG to verify that the correct device was used during shooting.
 */