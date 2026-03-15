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

        // Load the TIFF image from disk
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to work with TIFF‑specific functionality
            TiffImage tiffImage = (TiffImage)image;

            // Save the image back to TIFF format.
            // No modifications are performed, so the original pixel data is preserved.
            tiffImage.Save(outputPath);
        }
    }
}