using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.wmf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image using Aspose.Imaging unified loader
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WmfImage for WMF‑specific operations
            WmfImage wmfImage = (WmfImage)image;

            // Example processing: retrieve image size (you can add more processing here)
            int width = wmfImage.Width;
            int height = wmfImage.Height;
            Console.WriteLine($"Loaded WMF image: {width}x{height} pixels");

            // Save the image back to a file (could be the same format or another supported format)
            wmfImage.Save(outputPath);
        }
    }
}