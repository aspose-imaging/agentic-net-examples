using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output\\converted.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;

            // Convert to grayscale (optional, ensures grayscale source)
            dicomImage.Grayscale();

            // Prepare PNG options with an indexed color palette
            PngOptions pngOptions = new PngOptions
            {
                // Use indexed color type so the palette is applied
                ColorType = PngColorType.IndexedColor,
                // Generate a custom 256‑color palette based on the image content
                Palette = ColorPaletteHelper.GetCloseImagePalette(
                    (RasterImage)dicomImage,
                    256,
                    PaletteMiningMethod.Histogram)
            };

            // Save the PNG with the custom palette
            dicomImage.Save(outputPath, pngOptions);
        }
    }
}