using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Define output path (ensure it includes a directory)
        string outputPath = "output\\created.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a BMP image, fill with a gradient, embed a valid digital signature, and save
        using (BmpImage bmp = new BmpImage(200, 200))
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    int hue = (255 * x) / bmp.Width;
                    bmp.SetPixel(x, y, Color.FromArgb(255, hue, 0, 0));
                }
            }

            // Embed digital signature with a valid password
            bmp.EmbedDigitalSignature("secure123");

            // Save the image using BMP options
            bmp.Save(outputPath, new BmpOptions());
        }

        // Reload the saved image and attempt to embed a signature with an invalid short password
        using (RasterImage img = (RasterImage)Image.Load(outputPath))
        {
            try
            {
                img.EmbedDigitalSignature("123");
            }
            catch (Aspose.Imaging.CoreExceptions.ImageException ex)
            {
                Console.WriteLine($"HANDLED: {ex.Message}");
            }
        }
    }
}