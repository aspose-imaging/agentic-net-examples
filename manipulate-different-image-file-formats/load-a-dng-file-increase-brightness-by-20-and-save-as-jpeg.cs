// HOW-TO: Adjust DNG Brightness By 20% And Convert To JPEG Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Increase brightness by approximately 20%
                raster.AdjustBrightness(51);

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, jpegOptions);
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
 * 1. When a photographer needs to quickly brighten raw DNG files and deliver them as smaller JPEGs for web galleries.
 * 2. When an e‑commerce platform processes product photos captured in DNG format, enhancing visibility before storing them as JPEG thumbnails.
 * 3. When a mobile app backend receives raw camera images, applies a 20% brightness boost, and converts them to JPEG for faster client download.
 * 4. When a digital archiving system standardizes legacy DNG scans by adjusting exposure and saving them in a widely supported JPEG format.
 * 5. When a batch script automates post‑processing of raw images, increasing brightness and compressing them to JPEG for email distribution.
 */
