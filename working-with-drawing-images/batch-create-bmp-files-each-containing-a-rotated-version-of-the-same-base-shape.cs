using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    // Maps rotation angle to the corresponding RotateFlipType.
    static RotateFlipType GetRotateFlipType(int angle)
    {
        switch (angle)
        {
            case 90:
                return RotateFlipType.Rotate90FlipNone;
            case 180:
                return RotateFlipType.Rotate180FlipNone;
            case 270:
                return RotateFlipType.Rotate270FlipNone;
            default:
                return RotateFlipType.RotateNoneFlipNone;
        }
    }

    static void Main()
    {
        // Hard‑coded input path (base shape) and output directory.
        string inputPath = @"C:\temp\baseShape.png";
        string outputDir = @"C:\temp\RotatedBmp\";

        // Verify that the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Angles for which rotated BMP files will be generated.
        int[] angles = new[] { 0, 90, 180, 270 };

        foreach (int angle in angles)
        {
            // Build the output file path.
            string outputPath = Path.Combine(outputDir, $"rotated_{angle}.bmp");

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image, rotate it, and save as BMP.
            using (Image img = Image.Load(inputPath))
            {
                img.RotateFlip(GetRotateFlipType(angle));

                // BMP save options (24‑bpp).
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };

                img.Save(outputPath, bmpOptions);
            }
        }
    }
}