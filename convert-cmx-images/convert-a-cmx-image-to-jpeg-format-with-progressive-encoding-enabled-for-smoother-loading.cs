// HOW-TO: Convert CMX Image to Progressive JPEG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Source = new FileCreateSource(outputPath, false)
                };
                cmx.Save(outputPath, jpegOptions);
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
 * 1. When you need to display legacy CorelDRAW CMX artwork on a website, converting it to a progressive JPEG reduces load time for users on slow connections.
 * 2. When a batch processing service must transform CMX files into web‑friendly JPEGs with progressive rendering for smoother image loading in browsers.
 * 3. When integrating a .NET application that receives CMX design files and must store them as compressed JPEGs for archival or preview purposes.
 * 4. When creating thumbnails of CMX drawings for a mobile app, using progressive JPEGs improves perceived performance on cellular networks.
 * 5. When migrating a digital asset library from CorelDRAW formats to standard image formats, converting CMX to progressive JPEG ensures compatibility with most image viewers.
 */
