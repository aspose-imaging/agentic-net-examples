using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\sample_rotated_270.bmp";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Remember original dimensions
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Rotate 270 degrees clockwise without flipping
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);

                // Verify dimensions remain unchanged after rotation
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