using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\Rotated\sample.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image, rotate it, and save as EMF
        using (Image image = Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise without flipping
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Prepare EMF save options with rasterization settings
            var emfOptions = new EmfOptions
            {
                VectorRasterizationOptions = new EmfRasterizationOptions
                {
                    // Preserve original size after rotation
                    PageSize = image.Size
                }
            };

            // Save the rotated image as EMF
            image.Save(outputPath, emfOptions);
        }
    }
}