using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the TIFF image
        using (var image = (TiffImage)Image.Load(inputPath))
        {
            // Convert existing PathResources to a GraphicsPath
            var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter
                .ToGraphicsPath(image.ActiveFrame.PathResources.ToArray(), image.ActiveFrame.Size);

            // Create a Graphics instance (do NOT wrap in using)
            var graphics = new Graphics(image);

            // Draw the path onto the image with a red pen
            graphics.DrawPath(new Pen(Color.Red, 5), graphicsPath);

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}