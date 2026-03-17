using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomDitheringExample
{
    static void Main()
    {
        // Path to the source DICOM image
        string inputPath = "input.dcm";

        // Path where the dithered DICOM image will be saved
        string outputPath = "output.dcm";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply Floyd‑Steinberg dithering using a 4‑bit palette (16 colors)
            // The third parameter (customPalette) is null because we use the default palette
            dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

            // Prepare save options that preserve original metadata
            DicomOptions saveOptions = new DicomOptions
            {
                KeepMetadata = true
            };

            // Save the processed image back to DICOM format
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}