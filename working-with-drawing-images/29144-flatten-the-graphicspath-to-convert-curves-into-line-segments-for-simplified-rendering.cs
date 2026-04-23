using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Convert existing path resources to a GraphicsPath
            GraphicsPath graphicsPath = PathResourceConverter.ToGraphicsPath(
                image.ActiveFrame.PathResources.ToArray(),
                image.ActiveFrame.Size);

            // Flatten all curves in the path to line segments
            graphicsPath.Flatten();

            // Convert the flattened GraphicsPath back to path resources
            PathResource[] newResources = PathResourceConverter.FromGraphicsPath(
                graphicsPath,
                image.ActiveFrame.Size);

            // Replace the image's path resources with the flattened ones
            image.ActiveFrame.PathResources = new List<PathResource>(newResources);

            // Save the modified image
            image.Save(outputPath);
        }
    }
}