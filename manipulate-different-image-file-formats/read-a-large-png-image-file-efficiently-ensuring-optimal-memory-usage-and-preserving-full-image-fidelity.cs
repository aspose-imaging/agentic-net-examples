using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the large PNG file to be read.
        string sourcePath = @"C:\Images\large_input.png";

        // Path where the image will be saved after loading (optional, demonstrates preserving fidelity).
        string destinationPath = @"C:\Images\large_output.png";

        // Load the PNG image using the constructor that accepts a file path.
        // This follows the provided load rule and ensures the image is opened efficiently.
        using (PngImage pngImage = new PngImage(sourcePath))
        {
            // Example of accessing image properties without fully materializing extra data.
            int width = pngImage.Width;
            int height = pngImage.Height;
            Console.WriteLine($"Loaded PNG: {width}x{height} pixels");

            // Retrieve the original saving options to preserve all original settings
            // (bit depth, color type, compression level, etc.).
            PngOptions originalOptions = (PngOptions)pngImage.GetOriginalOptions();

            // Save the image using the original options to maintain full fidelity.
            // This follows the provided save rule.
            pngImage.Save(destinationPath, originalOptions);
        }
    }
}