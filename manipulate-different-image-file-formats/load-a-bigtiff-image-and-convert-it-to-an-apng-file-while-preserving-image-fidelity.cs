using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source BIGTIFF image
        string inputPath = @"C:\Images\source_big.tif";

        // Desired output path for the APNG file
        string outputPath = @"C:\Images\converted.apng";

        // Load the BIGTIFF image using Aspose.Imaging's Image.Load method.
        // The returned Image instance will be of type BigTiffImage.
        using (Image bigTiffImage = Image.Load(inputPath))
        {
            // Create APNG save options. Default options preserve the original pixel data.
            ApngOptions apngOptions = new ApngOptions();

            // Save the loaded image as an APNG file.
            // The Save method handles the conversion while keeping image fidelity.
            bigTiffImage.Save(outputPath, apngOptions);
        }
    }
}