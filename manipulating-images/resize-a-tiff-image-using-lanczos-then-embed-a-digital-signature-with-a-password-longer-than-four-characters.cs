// HOW-TO: Resize TIFF with Lanczos and Add Password Protected Digital Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output/output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                string password = "securePass";
                image.EmbedDigitalSignature(password);

                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, options);
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
 * 1. When you need to reduce the file size of a high‑resolution TIFF for faster web delivery while preserving image quality using Lanczos resampling.
 * 2. When you must protect a TIFF document by embedding a digital signature that requires a password longer than four characters for compliance or authenticity verification.
 * 3. When an automated workflow processes scanned TIFF files, resizes them to half their dimensions, and secures them before storing them in an archive.
 * 4. When a medical imaging system needs to downscale large TIFF scans and embed a password‑protected signature to ensure data integrity during transmission.
 * 5. When a desktop application generates TIFF reports, resizes them for printing, and adds a digital signature to prevent tampering.
 */
