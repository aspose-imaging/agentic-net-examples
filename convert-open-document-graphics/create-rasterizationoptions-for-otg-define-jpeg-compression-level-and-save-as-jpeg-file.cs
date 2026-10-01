// HOW-TO: Convert OTG Vector Image to JPEG with Quality Setting in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.otg";
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
                    Quality = 80,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
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
 * 1. When you need to display an OTG vector diagram on a web page that only supports JPEG images.
 * 2. When you want to generate thumbnail previews of OTG files with a specific compression quality for faster loading.
 * 3. When you are building a batch conversion tool that rasterizes vector graphics to JPEG while preserving background color.
 * 4. When you must integrate OTG to JPEG conversion into a C# reporting system that embeds images in PDF documents.
 * 5. When you require consistent page dimensions and a white background for OTG files before saving them as JPEG for archival.
 */
