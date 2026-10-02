// HOW-TO: Resize JPEG and Embed Password Protected Digital Signature in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.jpg";

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

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                int maxWidth = 800;
                int originalWidth = raster.Width;
                int originalHeight = raster.Height;

                int newWidth = originalWidth;
                int newHeight = originalHeight;

                if (originalWidth > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)((float)originalHeight * newWidth / originalWidth);
                }

                if (newWidth != originalWidth || newHeight != originalHeight)
                {
                    raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                }

                string password = "SecurePass123";
                raster.EmbedDigitalSignature(password);

                JpegOptions jpegOptions = new JpegOptions();
                jpegOptions.Source = new FileCreateSource(outputPath, false);
                jpegOptions.Quality = 90;

                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate smaller web‑ready JPEG thumbnails while ensuring the image can be authenticated later with a password‑protected digital signature.
 * 2. When an e‑commerce platform must automatically resize product photos to a maximum width and embed a secure signature to prevent image tampering.
 * 3. When a document management system stores scanned JPEGs and requires each file to be resized for storage efficiency and signed with a password for compliance.
 * 4. When a mobile app uploads user‑taken JPEGs, and the backend must reduce the image size and embed a digital signature to verify the source.
 * 5. When a digital asset pipeline needs to batch‑process JPEG images, maintaining aspect ratio, applying a quality setting, and adding a password‑protected signature for copyright protection.
 */
