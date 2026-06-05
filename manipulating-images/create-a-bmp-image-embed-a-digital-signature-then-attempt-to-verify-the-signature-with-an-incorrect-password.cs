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
            // Output file path
            string outputPath = "output\\signed.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions (minimum 200x200 as required for digital signatures)
            int width = 200;
            int height = 200;

            // Create BMP image and fill with a simple gradient
            using (var bmpImage = new BmpImage(width, height))
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int hue = (255 * x) / width;
                        bmpImage.SetPixel(x, y, Color.FromArgb(255, hue, 0, 0));
                    }
                }

                // Embed digital signature with a valid password
                bmpImage.EmbedDigitalSignature("secure123");

                // Save the signed image
                bmpImage.Save(outputPath);

                // Attempt to verify the signature with an incorrect password
                bool isSigned = bmpImage.IsDigitalSigned("123");
                Console.WriteLine($"Signature verification with incorrect password: {isSigned}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}