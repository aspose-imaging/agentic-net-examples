using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.psd";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Reset font settings to system defaults and update cache
            FontSettings.Reset();
            FontSettings.UpdateFonts();

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save as TIFF with embedded fonts
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}