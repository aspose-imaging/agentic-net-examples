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
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/sample_geotagged.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData as Aspose.Imaging.Exif.JpegExifData;
                if (exif == null)
                {
                    exif = new Aspose.Imaging.Exif.JpegExifData();
                }

                exif.GPSLatitude = new TiffRational[]
                {
                    new TiffRational(37, 1),
                    new TiffRational(48, 1),
                    new TiffRational(30, 1)
                };
                exif.GPSLatitudeRef = "N";

                exif.GPSLongitude = new TiffRational[]
                {
                    new TiffRational(122, 1),
                    new TiffRational(24, 1),
                    new TiffRational(0, 1)
                };
                exif.GPSLongitudeRef = "W";

                image.ExifData = exif;

                var jpegOptions = new JpegOptions();
                jpegOptions.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to embed GPS latitude and longitude EXIF tags into a JPEG image using C# and Aspose.Imaging for geotagging before publishing to a mapping service.
 * 2. When an application must programmatically add precise GPS coordinates to drone‑captured JPEG files so they can be sorted and displayed on geographic information system (GIS) platforms.
 * 3. When a photo‑organizing tool requires inserting latitude/longitude reference tags into existing JPEG images via Aspose.Imaging’s JpegExifData class to enable location‑based searches.
 * 4. When a real‑estate website wants to automatically tag property photos with accurate GPS EXIF data using C# so the listings appear correctly on interactive maps.
 * 5. When a mobile synchronization service processes user‑taken JPEGs and needs to ensure each file contains valid EXIF GPSLatitudeRef and GPSLongitudeRef tags for downstream analytics.
 */