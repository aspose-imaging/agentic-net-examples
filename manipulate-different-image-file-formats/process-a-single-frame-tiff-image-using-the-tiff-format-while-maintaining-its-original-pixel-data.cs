using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Path to the source single‑frame TIFF file
        string inputPath = "input.tif";

        // Path where the processed TIFF will be saved
        string outputPath = "output.tif";

        // Load the TIFF image from disk using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to TiffImage to work with TIFF‑specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Save the image back to TIFF format.
            // This uses the built‑in Save(string) rule and preserves the original pixel data.
            tiffImage.Save(outputPath);
        }
    }
}