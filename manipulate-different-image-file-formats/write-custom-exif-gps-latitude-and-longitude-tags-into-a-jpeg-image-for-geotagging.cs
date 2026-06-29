using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
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
                var exif = image.ExifData;
                if (exif == null)
                {
                    Console.Error.WriteLine("EXIF data not present in the image.");
                    return;
                }

                // Set GPS latitude and longitude tags (degrees, minutes, seconds)
                exif.GPSLatitude = new TiffRational[]
                {
                    new TiffRational(37, 1), // degrees
                    new TiffRational(0, 1),  // minutes
                    new TiffRational(0, 1)   // seconds
                };
                exif.GPSLatitudeRef = "N";

                exif.GPSLongitude = new TiffRational[]
                {
                    new TiffRational(122, 1), // degrees
                    new TiffRational(0, 1),   // minutes
                    new TiffRational(0, 1)    // seconds
                };
                exif.GPSLongitudeRef = "W";

                // Prepare JPEG save options with updated EXIF data
                JpegOptions saveOptions = new JpegOptions
                {
                    ExifData = exif,
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the image with the new EXIF GPS information
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to write GPS latitude and longitude EXIF tags into a JPEG image using C# and Aspose.Imaging for drone‑collected mapping data.
 * 2. When a developer wants to geotag user‑uploaded travel photos by setting the EXIF GPSLatitude and GPSLongitude fields in a JPEG file with Aspose.Imaging.
 * 3. When a developer must embed precise latitude/longitude metadata into scanned JPEG documents before importing them into a GIS system using Aspose.Imaging’s EXIF API.
 * 4. When a developer is building a real‑estate web application that adds location EXIF data to property JPEG images so they can be displayed on interactive maps.
 * 5. When a developer creates a C# photo‑organizer utility that writes GPS coordinates to JPEG EXIF metadata to enable location‑based sorting and searching.
 */