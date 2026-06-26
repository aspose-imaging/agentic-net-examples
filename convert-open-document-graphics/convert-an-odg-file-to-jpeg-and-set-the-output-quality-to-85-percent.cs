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
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.jpg";

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
                    Quality = 85
                };

                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                jpegOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer needs to generate web‑ready preview images from OpenDocument Graphics (ODG) files, converting them to JPEG with 85 % quality for faster page loads.
 * 2. When an automated document‑processing pipeline must archive vector drawings as compressed JPEG thumbnails while preserving a white background and original page size.
 * 3. When a desktop application allows users to export their ODG diagrams to a common raster format for inclusion in reports or presentations, using C# and Aspose.Imaging to control output quality.
 * 4. When a cloud service processes batch uploads of ODG files and creates JPEG versions with consistent 85 % quality for email attachments or social‑media sharing.
 * 5. When a migration tool converts legacy ODG assets to JPEG images for compatibility with systems that only support raster formats, ensuring the conversion respects the original dimensions and a white background.
 */