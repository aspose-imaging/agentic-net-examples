using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage =
            (Aspose.Imaging.FileFormats.Dicom.DicomImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Convert to grayscale (if not already)
            dicomImage.Grayscale();

            // Configure PNG options with an indexed color type and a custom grayscale palette
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.IndexedColor,
                Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false)
            };

            // Save the image as PNG using the custom palette
            dicomImage.Save(outputPath, pngOptions);
        }
    }
}