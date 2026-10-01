// HOW-TO: Convert ODG to Progressive JPEG for Faster Web Loading in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive
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
 * 1. When you need to display OpenDocument graphics on a website, converting ODG files to progressive JPEG reduces initial load time for visitors.
 * 2. When building a C# image‑processing pipeline that ingests LibreOffice drawings and outputs web‑optimized photos, you can use this code to generate progressive JPEGs automatically.
 * 3. When a content management system stores design assets as ODG and must serve them as JPEG thumbnails, the progressive encoding speeds up thumbnail rendering in browsers.
 * 4. When migrating legacy documentation that contains ODG diagrams to a modern HTML portal, converting them to progressive JPEG ensures compatibility with all browsers while keeping file size low.
 * 5. When creating an automated report generator that embeds ODG charts into email newsletters, saving them as progressive JPEGs improves email load performance on mobile devices.
 */
