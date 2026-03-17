using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Path to the source BigTIFF image (can be .tif, .btif, etc.)
        string sourcePath = "big_image.tif";

        // Desired output path for the APNG file
        string outputPath = "big_image.apng";

        // Load the BigTIFF image using the standard Image.Load method
        using (Image bigTiff = Image.Load(sourcePath))
        {
            // Prepare APNG save options.
            // Using default ApngOptions preserves as much of the original image data as possible.
            ApngOptions apngOptions = new ApngOptions
            {
                // Example: keep the original resolution if needed
                // ResolutionSettings = new ResolutionSetting { HorizontalResolution = bigTiff.HorizontalResolution, VerticalResolution = bigTiff.VerticalResolution }
            };

            // Save the loaded image as an APNG file.
            // The Save method handles the conversion while maintaining image fidelity.
            bigTiff.Save(outputPath, apngOptions);
        }
    }
}