using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Load a TIFF image from disk
        using (Image image = Image.Load("input.tif"))
        {
            // Retrieve the original saving options derived from the loaded file
            ImageOptionsBase originalOptions = image.GetOriginalOptions();

            // If the options are specific to TIFF, cast to TiffOptions to access native metadata
            if (originalOptions is TiffOptions tiffOptions)
            {
                // Example: output some TIFF-specific settings
                Console.WriteLine($"BitsPerSample: {tiffOptions.BitsPerSample}");
                Console.WriteLine($"Compression: {tiffOptions.Compression}");
                Console.WriteLine($"Photometric: {tiffOptions.Photometric}");
            }

            // Save the image using the original options to preserve its original characteristics
            image.Save("output.tif", originalOptions);
        }
    }
}