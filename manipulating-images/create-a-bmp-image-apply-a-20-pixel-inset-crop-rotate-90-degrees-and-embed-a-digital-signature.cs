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
            // Define output path (includes directory to satisfy Directory.CreateDirectory)
            string outputPath = "output/output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image with sufficient size (>=200x200)
            using (BmpImage bmp = new BmpImage(300, 300))
            {
                // Apply a 20-pixel inset crop (left, right, top, bottom)
                bmp.Crop(20, 20, 20, 20);

                // Rotate the image by 90 degrees
                bmp.Rotate(90);

                // Embed a digital signature with a valid password
                bmp.EmbedDigitalSignature("secure123");

                // Save the processed image to the specified path
                BmpOptions options = new BmpOptions();
                bmp.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}