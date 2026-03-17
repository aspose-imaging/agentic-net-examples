using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source WMF file
        string inputPath = @"C:\Images\source.wmf";

        // Path where the cropped WMF will be saved
        string outputPath = @"C:\Images\cropped.wmf";

        // Load the WMF image using Aspose.Imaging's unified loader
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WmfImage to access WMF‑specific functionality
            WmfImage wmfImage = (WmfImage)image;

            // Define the rectangle to crop (example: central half of the image)
            int x = wmfImage.Width / 4;
            int y = wmfImage.Height / 4;
            int width = wmfImage.Width / 2;
            int height = wmfImage.Height / 2;
            Rectangle cropArea = new Rectangle(x, y, width, height);

            // Crop the image; metadata remains attached to the image object
            wmfImage.Crop(cropArea);

            // Save the cropped image back to WMF format, preserving metadata
            wmfImage.Save(outputPath, new WmfOptions());
        }
    }
}