using System;
using System.IO;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "output";
            string originalPath = Path.Combine(outputDir, "original.bmp");
            string signedPath = Path.Combine(outputDir, "signed.bmp");

            // Create BMP image
            using (var bmpImage = new BmpImage(100, 100))
            {
                for (int y = 0; y < bmpImage.Height; y++)
                {
                    for (int x = 0; x < bmpImage.Width; x++)
                    {
                        int hue = (255 * x) / bmpImage.Width;
                        bmpImage.SetPixel(x, y, Aspose.Imaging.Color.FromArgb(255, hue, 0, 0));
                    }
                }

                Directory.CreateDirectory(Path.GetDirectoryName(originalPath));
                bmpImage.Save(originalPath);
            }

            if (!File.Exists(originalPath))
            {
                Console.Error.WriteLine($"File not found: {originalPath}");
                return;
            }

            // Load image, embed digital signature, and save signed image
            using (var image = Aspose.Imaging.Image.Load(originalPath))
            {
                var raster = (Aspose.Imaging.RasterImage)image;
                raster.EmbedDigitalSignature("secure123");

                Directory.CreateDirectory(Path.GetDirectoryName(signedPath));
                raster.Save(signedPath);
            }

            if (!File.Exists(signedPath))
            {
                Console.Error.WriteLine($"File not found: {signedPath}");
                return;
            }

            // Verify signature with incorrect password
            using (var signedImage = Aspose.Imaging.Image.Load(signedPath))
            {
                var rasterSigned = (Aspose.Imaging.RasterImage)signedImage;
                bool isSigned = rasterSigned.IsDigitalSigned("123");
                Console.WriteLine($"Signature verification with incorrect password: {isSigned}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}