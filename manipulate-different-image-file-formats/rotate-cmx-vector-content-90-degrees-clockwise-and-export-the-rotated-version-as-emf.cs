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
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.cmx";
        string outputPath = @"C:\temp\sample_rotated.emf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image, rotate it, and save as EMF
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise without flipping
            cmxImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the rotated image as EMF using default options
            cmxImage.Save(outputPath, new EmfOptions());
        }
    }
}