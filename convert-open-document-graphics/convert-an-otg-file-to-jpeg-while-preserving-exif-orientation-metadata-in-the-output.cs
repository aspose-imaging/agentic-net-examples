// HOW-TO: Convert OTG to JPEG While Keeping EXIF Orientation in C# (Aspose.Imaging for .NET)
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
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.jpg");

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
                var jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to display OTG images on web pages that only support JPEG, preserving the original orientation so they appear correctly.
 * 2. When migrating a legacy archive of OTG files to a standard JPEG format for compatibility with mobile apps while retaining camera orientation metadata.
 * 3. When building an automated image processing pipeline that converts raw OTG scans to JPEG thumbnails without losing EXIF rotation information.
 * 4. When integrating Aspose.Imaging into a C# desktop application that imports OTG files and saves them as JPEG for printing, ensuring the orientation stays accurate.
 * 5. When creating a batch conversion tool that processes multiple OTG files into JPEG for cloud storage, keeping EXIF orientation for downstream image analysis.
 */
