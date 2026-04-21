using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.cmx";
        string outputPath = @"C:\Images\output.cmx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (CmxImage image = (CmxImage)Image.Load(inputPath))
        {
            // Calculate new dimensions (scale uniformly by factor of 2)
            int newWidth = image.Width * 2;
            int newHeight = image.Height * 2;

            // Resize the image – this scales drawing elements and line thickness proportionally
            image.Resize(newWidth, newHeight);

            // Save the scaled image to the output path
            image.Save(outputPath);
        }
    }
}