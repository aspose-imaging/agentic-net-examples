using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Path to the WMF file
        string wmfFilePath = "input.wmf";

        // Load the WMF image using the unified loader
        using (Image image = Image.Load(wmfFilePath))
        {
            // Cast to WmfImage to access WMF‑specific properties
            WmfImage wmfImage = (WmfImage)image;

            // Example usage: output image dimensions
            Console.WriteLine($"Width: {wmfImage.Width}, Height: {wmfImage.Height}");
        }
    }
}