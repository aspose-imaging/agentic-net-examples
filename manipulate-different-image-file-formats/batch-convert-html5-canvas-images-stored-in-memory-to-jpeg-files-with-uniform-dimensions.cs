// HOW-TO: Batch Convert Images to JPEG with Fixed Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            int targetWidth = 800;
            int targetHeight = 600;

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] inputFiles = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (!image.IsCached)
                        image.CacheData();

                    image.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                    JpegOptions jpegOptions = new JpegOptions()
                    {
                        Source = new FileCreateSource(outputPath, false),
                        Quality = 90
                    };

                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate thumbnails of user‑uploaded pictures for a web gallery by resizing them to a standard width and height and saving them as JPEGs.
 * 2. When you have a folder of raw canvas screenshots that must be compressed into smaller JPEG files for faster page load times.
 * 3. When an automated build process must convert a batch of PNG or BMP assets into uniform‑size JPEGs for inclusion in a mobile app.
 * 4. When you want to archive a collection of images with consistent dimensions and JPEG quality to meet a third‑party API’s image specifications.
 * 5. When a server‑side service processes incoming image files, resizes them to 800×600, and stores the results as JPEGs for downstream reporting.
 */
