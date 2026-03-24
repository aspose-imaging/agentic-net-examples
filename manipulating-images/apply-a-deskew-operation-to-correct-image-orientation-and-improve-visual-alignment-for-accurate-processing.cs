using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image as a RasterImage and apply deskew (NormalizeAngle)
        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Deskew without resizing the canvas, using LightGray as background color
            image.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);
            // Save the corrected image
            image.Save(outputPath);
        }
    }
}