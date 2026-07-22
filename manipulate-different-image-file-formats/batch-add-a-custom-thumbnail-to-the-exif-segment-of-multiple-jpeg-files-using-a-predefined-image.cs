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

            string thumbnailPath = "thumbnail.jpg";

            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            using (RasterImage thumbnail = (RasterImage)Image.Load(thumbnailPath))
            {
                string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

                foreach (string inputPath in jpegFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (RasterImage image = (RasterImage)Image.Load(inputPath))
                    {
                        if (!image.IsCached)
                            image.CacheData();

                        image.Blend(new Point(0, 0), thumbnail, 255);

                        JpegOptions options = new JpegOptions
                        {
                            Quality = 90
                        };

                        image.Save(outputPath, options);
                    }
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
 * 1. When a photographer uses C# and Aspose.Imaging to embed a custom logo thumbnail into the EXIF segment of every JPEG before publishing the images online.
 * 2. When an e‑commerce site automates batch processing of product JPEGs with Aspose.Imaging to add a branded thumbnail to the EXIF metadata so that previews display correctly in browsers and file managers.
 * 3. When a digital asset management tool leverages the RasterImage class and JpegOptions to insert a standardized thumbnail into the EXIF of legacy JPEG files for faster thumbnail browsing in Windows Explorer.
 * 4. When a mobile app developer employs Aspose.Imaging for .NET to pre‑populate the EXIF thumbnail of user‑generated JPEGs with a placeholder image, ensuring consistent UI across devices.
 * 5. When a news organization runs a C# script using Aspose.Imaging to add a copyright watermark thumbnail to the EXIF of thousands of archived JPEGs, guaranteeing proper attribution when the files are shared.
 */