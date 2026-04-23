using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.dcm";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific features
                DicomImage dicomImage = (DicomImage)image;

                // Convert the image to grayscale (if not already)
                dicomImage.Grayscale();

                int pageIndex = 0;
                // Iterate through each page of the DICOM image
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build the output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PNG options with an indexed color type and a custom grayscale palette
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.IndexedColor,
                        // Use an 8‑bit grayscale palette as the custom palette
                        Palette = ColorPaletteHelper.Create8BitGrayscale(false)
                    };

                    // Save the current DICOM page as a PNG using the specified options
                    dicomPage.Save(outputPath, pngOptions);

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}