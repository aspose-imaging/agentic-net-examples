using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve existing clipping paths
            List<PathResource> paths = image.ActiveFrame.PathResources;

            if (paths == null || paths.Count == 0)
            {
                Console.WriteLine("No clipping paths found in the image.");
                // Optionally, you could create a new path here.
            }
            else
            {
                // Example modification: keep only the first clipping path and rename it
                PathResource firstPath = paths[0];
                firstPath.Name = "Adjusted Clipping Path";

                // Replace the PathResources collection with the modified single path
                image.ActiveFrame.PathResources = new List<PathResource> { firstPath };
            }

            // Save the modified image
            image.Save(outputPath);
        }
    }
}