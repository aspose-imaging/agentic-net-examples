using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class RetrieveTiffOriginalOptions
{
    static void Main()
    {
        // Path to the source TIFF image
        string inputPath = "input.tif";

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to TiffImage to access TIFF‑specific members
            TiffImage tiffImage = (TiffImage)image;

            // Retrieve the original saving options derived from the source file
            TiffOptions originalOptions = (TiffOptions)tiffImage.GetOriginalOptions();

            // Access native compression type
            var compression = originalOptions.Compression;

            // Example: output compression and other relevant settings
            Console.WriteLine($"Original Compression: {compression}");
            Console.WriteLine($"Bits Per Sample: {originalOptions.BitsPerSample}");
            Console.WriteLine($"Photometric: {originalOptions.Photometric}");
            Console.WriteLine($"Resolution Unit: {originalOptions.ResolutionUnit}");
        }
    }
}