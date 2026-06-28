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
            // Hardcoded input and output paths
            string inputPath = "sample.jpg";
            string outputPath = "output\\result.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access JPEG-specific EXIF data
                JpegExifData jpegExif = image.ExifData as JpegExifData;
                if (jpegExif != null && !string.IsNullOrEmpty(jpegExif.Model))
                {
                    Console.WriteLine($"Camera model: {jpegExif.Model}");
                }
                else
                {
                    Console.WriteLine("Camera model tag not found.");
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
 * 1. When a developer builds a photo‑gallery web app in C# and needs to display the camera model next to each JPEG thumbnail, they can use Aspose.Imaging to read the EXIF Model tag as shown.
 * 2. When a digital‑asset‑management system must generate a report of all camera models used in a collection of JPEG files, this code extracts the Model tag for each image.
 * 3. When a mobile‑photo‑upload service wants to validate that images were taken with a specific device, it can read the JPEG EXIF data in C# to compare the camera model.
 * 4. When an e‑commerce platform processes product photos and wants to log the source camera for quality‑control auditing, the Aspose.Imaging EXIF reader provides the model information.
 * 5. When a forensic‑analysis tool needs to quickly identify the make of a camera from a suspect’s JPEG evidence, the C# snippet demonstrates how to retrieve the Model tag from the image’s EXIF metadata.
 */