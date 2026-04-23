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
            string outputPath = "signed.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image 200x200 pixels
            using (BmpImage bmp = new BmpImage(200, 200))
            {
                // Fill the image with a simple gradient
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        int hue = (255 * x) / bmp.Width;
                        bmp.SetPixel(x, y, Color.FromArgb(255, hue, 0, 0));
                    }
                }

                // Embed a digital signature with a valid password
                ((RasterImage)bmp).EmbedDigitalSignature("secure123");

                // Save the signed image
                bmp.Save(outputPath, new BmpOptions());
            }

            // Verify error handling with an invalid password
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (Image img = Image.Load(outputPath))
            {
                RasterImage raster = (RasterImage)img;
                try
                {
                    // Attempt to embed with an invalid password
                    raster.EmbedDigitalSignature("123");
                }
                catch (Aspose.Imaging.CoreExceptions.ImageException ex)
                {
                    Console.WriteLine($"HANDLED: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}