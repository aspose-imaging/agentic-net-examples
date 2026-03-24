using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Sample.tif";
        string outputPath = "ClippingPaths.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (creates current directory if null)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve clipping path names
            List<string> pathNames = new List<string>();
            foreach (PathResource path in image.ActiveFrame.PathResources)
            {
                pathNames.Add(path.Name);
                Console.WriteLine(path.Name);
            }

            // Write the names to the output text file
            File.WriteAllLines(outputPath, pathNames);
        }
    }
}