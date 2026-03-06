using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class LoadWmfExample
{
    static void Main()
    {
        // Path to the WMF file
        string wmfFilePath = @"C:\Images\sample.wmf";

        // Load the image using Aspose.Imaging's unified Load method
        using (Image image = Image.Load(wmfFilePath))
        {
            // Cast the generic Image to a WmfImage for WMF‑specific access
            WmfImage wmfImage = (WmfImage)image;

            // Example: retrieve basic properties
            int width = wmfImage.Width;
            int height = wmfImage.Height;

            Console.WriteLine($"WMF image loaded successfully. Size: {width}x{height}");
        }
    }
}