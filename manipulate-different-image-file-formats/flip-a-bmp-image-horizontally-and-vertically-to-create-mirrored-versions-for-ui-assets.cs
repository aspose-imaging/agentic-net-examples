using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.bmp";
        string horizontalOutputPath = @"C:\temp\output\source_horiz.bmp";
        string verticalOutputPath = @"C:\temp\output\source_vert.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create horizontal mirrored image
            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                Directory.CreateDirectory(Path.GetDirectoryName(horizontalOutputPath));
                image.Save(horizontalOutputPath);
            }

            // Create vertical mirrored image
            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Directory.CreateDirectory(Path.GetDirectoryName(verticalOutputPath));
                image.Save(verticalOutputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}