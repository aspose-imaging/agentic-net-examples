// HOW-TO: How to Write Custom EXIF GPS Latitude and Longitude to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    double latitude = 37.7749;   // example latitude
                    double longitude = -122.4194; // example longitude

                    exif.GPSLatitude = new TiffRational[] { new TiffRational((uint)Math.Abs(latitude), 1) };
                    exif.GPSLatitudeRef = latitude >= 0 ? "N" : "S";

                    exif.GPSLongitude = new TiffRational[] { new TiffRational((uint)Math.Abs(longitude), 1) };
                    exif.GPSLongitudeRef = longitude >= 0 ? "E" : "W";
                }

                var saveOptions = new JpegOptions();
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
 * 1. When you need to add or update GPS coordinates in a JPEG photo for location‑based services using C# and Aspose.Imaging.
 * 2. When building a desktop application that automatically geotags images taken offline before uploading them to a mapping platform.
 * 3. When creating a batch process that embeds latitude and longitude into travel‑journal photos to enable map previews in web galleries.
 * 4. When integrating image metadata editing into a real‑estate listing tool to show property locations directly on the property photos.
 * 5. When developing a mobile‑to‑desktop sync solution that adds precise GPS tags to user‑captured JPEGs for archival and compliance purposes.
 */
