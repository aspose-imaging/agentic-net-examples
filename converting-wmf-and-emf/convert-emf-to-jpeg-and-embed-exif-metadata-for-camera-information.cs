// HOW-TO: Convert EMF Vector Image to JPEG with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.emf";
        string outputPath = "Output\\sample.jpg";

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
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When a Windows desktop application must display legacy EMF graphics as JPEG thumbnails in a web gallery.
 * 2. When generating printable PDF reports that require embedding high‑resolution JPEG versions of vector EMF logos.
 * 3. When converting EMF diagrams to JPEG for email attachments where only raster formats are supported.
 * 4. When a batch process needs to rasterize EMF files to JPEG with a consistent white background for archival storage.
 * 5. When integrating Aspose.Imaging in a C# service to transform vector drawings into JPEGs while preserving original dimensions.
 */
