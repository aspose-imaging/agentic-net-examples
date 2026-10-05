// HOW-TO: Resize BMP Image With Bicubic Resampling And Add Password Protected Digital Signature In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int newWidth = Math.Max(1, image.Width / 2);
                int newHeight = Math.Max(1, image.Height / 2);
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                image.EmbedDigitalSignature("Password12");
                BmpOptions options = new BmpOptions();
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
 * 1. When a desktop application needs to shrink large BMP files while preserving quality using bicubic scaling before storing them.
 * 2. When a document management system must embed a tamper‑evident digital signature into a BMP so only users with the correct password can verify its integrity.
 * 3. When an automated batch process resizes scanned BMP images to half size and secures them with a password‑protected signature for archival compliance.
 * 4. When a medical imaging workflow requires reducing BMP resolution for faster transmission and adding a digital signature to ensure patient data hasn't been altered.
 * 5. When a game asset pipeline needs to downscale BMP textures and embed a password‑protected signature to prevent unauthorized modification.
 */
