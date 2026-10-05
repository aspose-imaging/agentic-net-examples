// HOW-TO: Update DateTimeOriginal EXIF Tag In JPEG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
                Aspose.Imaging.Exif.JpegExifData exif = image.ExifData;
                if (exif != null)
                {
                    exif.DateTimeOriginal = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss");
                }

                JpegOptions options = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, options);
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
 * 1. When you need to correct or set the original capture date of photos before uploading them to a gallery or cloud service.
 * 2. When a batch script must rewrite the DateTimeOriginal metadata of JPEGs to match the current system time for compliance with archival standards.
 * 3. When an application generates images on the fly and must embed accurate timestamp metadata for later sorting or searching.
 * 4. When you are preparing product photos for e‑commerce platforms that require a valid EXIF DateTimeOriginal field to avoid listing errors.
 * 5. When a digital forensics tool needs to update the capture timestamp of JPEG evidence without altering the image pixels.
 */
