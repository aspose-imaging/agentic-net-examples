using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\test.dng";
        string outputPath = @"c:\temp\test.png";

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
            // Load DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to access DNG-specific properties
                DngImage dngImage = (DngImage)image;

                // Set background color to white
                dngImage.HasBackgroundColor = true;
                dngImage.BackgroundColor = Color.White;

                // Save as PNG with default options
                dngImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}