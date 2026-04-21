using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image with dimensions at least 200x200 (required for digital signature)
            using (BmpImage bmp = new BmpImage(200, 200))
            {
                // Fill the image with white color
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        bmp.SetPixel(x, y, Color.White);
                    }
                }

                // Apply a 20-pixel inset crop (left, right, top, bottom)
                bmp.Crop(20, 20, 20, 20);

                // Rotate the image 90 degrees clockwise
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Embed a digital signature using a valid password
                bmp.EmbedDigitalSignature("secure123");

                // Save the processed BMP image
                bmp.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}