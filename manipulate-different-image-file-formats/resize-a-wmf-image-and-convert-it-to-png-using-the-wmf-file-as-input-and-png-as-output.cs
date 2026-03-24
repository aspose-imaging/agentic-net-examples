using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample_resized.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image, resize it, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WmfImage to access WMF-specific functionality
            WmfImage wmfImage = (WmfImage)image;

            // Example: resize to half of the original dimensions
            int newWidth = wmfImage.Width / 2;
            int newHeight = wmfImage.Height / 2;

            // Perform the resize operation
            wmfImage.Resize(newWidth, newHeight);

            // Save the resized image as PNG
            wmfImage.Save(outputPath, new PngOptions());
        }
    }
}