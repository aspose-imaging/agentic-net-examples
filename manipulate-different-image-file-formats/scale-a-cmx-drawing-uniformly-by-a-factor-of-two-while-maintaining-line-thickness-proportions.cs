using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.cmx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX drawing, resize uniformly by factor of 2, and save
        using (CmxImage image = (CmxImage)Image.Load(inputPath))
        {
            // Scale width and height by 2, preserving line thickness proportionally
            image.Resize(image.Width * 2, image.Height * 2, ResizeType.NearestNeighbourResample);
            image.Save(outputPath);
        }
    }
}