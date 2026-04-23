using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample_scaled.cmx";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CMX image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Calculate new dimensions (scale uniformly by factor of 2)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize the image; this scales the drawing and line thickness proportionally
                image.Resize(newWidth, newHeight);

                // Save the scaled image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}