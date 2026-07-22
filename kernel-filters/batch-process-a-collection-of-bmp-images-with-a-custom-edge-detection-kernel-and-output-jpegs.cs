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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When a developer needs to convert a folder of legacy BMP screenshots into compressed JPEG files for faster web page loading.
 * 2. When an automated build script must process scanned BMP documents in bulk and store them as JPEGs for archival in a cloud storage bucket.
 * 3. When a photo‑management application has to streamline its import pipeline by reading BMP assets and saving them as JPEGs to reduce disk usage.
 * 4. When a Windows service monitors an input directory, transforms each BMP image to JPEG, and places the results in an output folder for downstream processing.
 * 5. When a data‑migration tool must batch‑convert legacy BMP icons to JPEG format before importing them into a modern content management system.
 */