using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input WMF file path
        string inputFile = @"C:\Images\sample.wmf";

        // Output PNG file path
        string outputFile = @"C:\Images\sample_resized.png";

        // Desired dimensions (example: half of original size)
        using (Image image = Image.Load(inputFile))
        {
            // Cast the loaded image to WmfImage to access WMF‑specific methods
            WmfImage wmfImage = (WmfImage)image;

            // Calculate new width and height (here we scale down by 50%)
            int newWidth = wmfImage.Width / 2;
            int newHeight = wmfImage.Height / 2;

            // Resize the WMF image using NearestNeighbour resampling
            wmfImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Save the resized image as PNG using the built‑in PngOptions
            wmfImage.Save(outputFile, new PngOptions());
        }
    }
}