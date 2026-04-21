using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\sample_rotated.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image, rotate 90° clockwise, and save as JPEG
        using (Image image = Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise without flipping
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the result as JPEG
            image.Save(outputPath, new JpegOptions());
        }
    }
}