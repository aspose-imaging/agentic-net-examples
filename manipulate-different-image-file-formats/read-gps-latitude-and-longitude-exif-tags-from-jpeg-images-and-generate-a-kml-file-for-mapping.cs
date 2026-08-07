using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\photo.jpg";
            string outputPath = "output\\photo.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When a travel‑blogger wants to automatically plot the locations where their JPEG photos were taken, they can use Aspose.Imaging for .NET to read GPS latitude and longitude EXIF tags and create a KML file that can be opened in Google Earth.
 * 2. When a real‑estate company needs to generate a property‑listing map from a batch of property‑site photos, they can extract the embedded GPS coordinates from each JPEG and produce a KML overlay showing each house’s exact position.
 * 3. When a field‑service organization wants to audit the routes of its technicians, they can process the JPEG images captured on site, read the EXIF GPS data, and output a KML file that visualizes all service locations on a map.
 * 4. When a wildlife researcher collects camera‑trap images, they can programmatically read the GPS EXIF tags from each JPEG and generate a KML file to visualize animal sightings across a conservation area.
 * 5. When a logistics company needs to verify delivery proof, they can extract GPS coordinates from delivery‑confirmation photos and compile them into a KML file that maps every drop‑off point for compliance reporting.
 */