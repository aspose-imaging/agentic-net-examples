using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "Sample.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve clipping paths (PathResources) from the active frame
            var paths = image.ActiveFrame.PathResources;

            if (paths == null || paths.Count == 0)
            {
                Console.WriteLine("No clipping paths found in the TIFF image.");
            }
            else
            {
                Console.WriteLine($"Found {paths.Count} clipping path(s):");
                foreach (var path in paths)
                {
                    // Display the name of each path
                    Console.WriteLine($"- {path.Name}");
                }
            }
        }
    }
}