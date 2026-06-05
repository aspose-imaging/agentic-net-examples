using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output_rotated.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image, rotate, verify dimensions, and save
            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Rotate 270 degrees clockwise without flipping
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);

                // Verify dimensions remain unchanged
                if (image.Width != originalWidth || image.Height != originalHeight)
                {
                    Console.Error.WriteLine("Dimensions changed after rotation.");
                }
                else
                {
                    Console.WriteLine("Dimensions unchanged after rotation.");
                }

                // Save the rotated image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}