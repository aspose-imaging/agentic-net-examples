// HOW-TO: Convert HTML Canvas Image to JPEG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
        string inputPath = "input.html";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Image image = Image.Load(inputStream))
                {
                    JpegOptions jpegOptions = new JpegOptions
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
 * 1. When you need to generate JPEG thumbnails from HTML5 canvas drawings stored on a server using C#.
 * 2. When converting user‑created canvas artwork uploaded as .html files into JPEGs for email attachments.
 * 3. When automating batch processing of HTML canvas reports into compressed JPEG images for archival.
 * 4. When integrating Aspose.Imaging into a web API that receives canvas HTML streams and returns JPEG responses.
 * 5. When migrating legacy HTML5 canvas assets to a JPEG format for compatibility with older image viewers.
 */
