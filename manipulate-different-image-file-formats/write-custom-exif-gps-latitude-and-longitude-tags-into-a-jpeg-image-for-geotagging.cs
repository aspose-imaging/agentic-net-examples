using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tiff;

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
            using (Image image = Image.Load(inputPath))
            {
                var jpegImage = image as JpegImage;
                if (jpegImage == null)
                {
                    Console.Error.WriteLine("The input file is not a JPEG image.");
                    return;
                }

                // Access or create EXIF data container
                var exif = jpegImage.ExifData;
                if (exif == null)
                {
                    exif = new Aspose.Imaging.Exif.JpegExifData();
                    jpegImage.ExifData = (Aspose.Imaging.Exif.JpegExifData)exif;
                }

                // Set GPS latitude (e.g., 37°0'0\" N) and longitude (e.g., 122°0'0\" W)
                exif.GPSLatitude = new TiffRational[]
                {
                    new TiffRational(37, 1),
                    new TiffRational(0, 1),
                    new TiffRational(0, 1)
                };
                exif.GPSLatitudeRef = "N";

                exif.GPSLongitude = new TiffRational[]
                {
                    new TiffRational(122, 1),
                    new TiffRational(0, 1),
                    new TiffRational(0, 1)
                };
                exif.GPSLongitudeRef = "W";

                // Save the modified image
                jpegImage.Save(outputPath);
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
 * 1. When a developer needs to embed GPS coordinates into a JPEG photo taken by a drone for mapping applications, they can use this code to write EXIF GPS latitude and longitude tags.
 * 2. When a mobile app processes user‑uploaded images and wants to add or correct location data before storing them in a cloud gallery, this C# snippet can set the EXIF GPS latitude and longitude fields.
 * 3. When an e‑commerce platform automatically tags product photos with the store’s physical address for location‑based search, the code can write the required GPS EXIF tags into the JPEG files.
 * 4. When a real‑estate website generates virtual tours and must geotag each property image to integrate with mapping services, developers can apply this code to insert the correct latitude and longitude into the JPEG EXIF data.
 * 5. When a scientific research tool collects field photographs and needs to embed precise coordinates for later GIS analysis, the example shows how to programmatically add GPS EXIF tags to the JPEG images using Aspose.Imaging for .NET.
 */