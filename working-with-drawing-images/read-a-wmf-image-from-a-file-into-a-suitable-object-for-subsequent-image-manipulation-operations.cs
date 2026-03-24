using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\output\sample_processed.wmf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WMF image for further manipulation
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Example operation: retrieve image dimensions
            int width = wmfImage.Width;
            int height = wmfImage.Height;
            Console.WriteLine($"Loaded WMF image: {width}x{height}");
            
            // Additional manipulation can be performed here
        }
    }
}