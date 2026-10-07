// HOW-TO: Export EMF as High Quality JPEG with 95% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output\\output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 95
                };
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
 * 1. When a developer needs to embed vector graphics from a Windows Metafile into a web page that only supports JPEG images, they can convert the EMF to a high‑quality JPEG using this code.
 * 2. When generating thumbnails for reports and the source images are stored as EMF, the snippet lets you create JPEG previews with a controlled 95 % quality setting.
 * 3. When migrating legacy design assets from EMF to a format suitable for mobile apps, this code provides a simple C# way to export them as JPEGs without losing visual fidelity.
 * 4. When automating a batch process that converts EMF logos to JPEG for email newsletters, the example shows how to set the JPEG compression level to maintain crispness.
 * 5. When integrating Aspose.Imaging into a document‑generation pipeline that outputs JPEG images, the snippet demonstrates loading an EMF and saving it with a specific quality parameter.
 */
