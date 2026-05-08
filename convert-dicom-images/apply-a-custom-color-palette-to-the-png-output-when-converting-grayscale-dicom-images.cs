using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.png";

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
                // Cast to DicomImage for DICOM-specific operations
                DicomImage dicomImage = (DicomImage)image;

                // Ensure the image is in grayscale (optional, safe for already grayscale images)
                dicomImage.Grayscale();

                // Prepare PNG save options with a custom palette
                PngOptions pngOptions = new PngOptions
                {
                    // Use indexed color so the palette is applied
                    ColorType = PngColorType.IndexedColor,

                    // Generate a palette based on the image content (custom palette)
                    Palette = ColorPaletteHelper.GetCloseImagePalette(
                        (RasterImage)dicomImage,
                        256,
                        PaletteMiningMethod.Histogram)
                };

                // Save the PNG with the custom palette
                dicomImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}