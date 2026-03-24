using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output\\rotated.jpg";

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
            // Desired rotation angle (degrees, clockwise)
            float angle = 45f;

            // Rotate while preserving metadata.
            // If the image is a raster image we can control background and resizing.
            if (image is RasterImage raster)
            {
                // Resize proportionally so the whole rotated image fits,
                // use white as background for any empty areas.
                raster.Rotate(angle, true, Aspose.Imaging.Color.White);
            }
            else
            {
                // Fallback to simple rotation for non‑raster formats.
                image.Rotate(angle);
            }

            // Save the rotated image
            image.Save(outputPath);
        }
    }
}