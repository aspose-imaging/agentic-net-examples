using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Path to the WMF file
        string wmfFilePath = @"C:\Images\sample.wmf";

        // Load the image using the unified Image.Load method
        using (Image image = Image.Load(wmfFilePath))
        {
            // Cast the generic Image to a WmfImage for WMF‑specific operations
            WmfImage wmfImage = (WmfImage)image;

            // Example: access basic properties
            int width = wmfImage.Width;
            int height = wmfImage.Height;
            Console.WriteLine($"Loaded WMF image: {width}x{height}");

            // Optional: cache data if you need to work with records later
            wmfImage.CacheData();

            // Further processing can be done here...
        }
    }
}