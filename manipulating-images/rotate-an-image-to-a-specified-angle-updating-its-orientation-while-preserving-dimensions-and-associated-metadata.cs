using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Rotate while preserving original dimensions
            if (image is RasterImage raster)
            {
                // Rotate 45 degrees clockwise, do not resize, use transparent background
                raster.Rotate(45f, false, Color.Transparent);
            }
            else
            {
                // Fallback for formats that only support RotateFlip (e.g., 90-degree steps)
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            // Save the rotated image
            image.Save(outputPath);
        }
    }
}