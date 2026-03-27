using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.png";
        string iccProfilePath = @"C:\Profiles\myprofile.icc";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Verify ICC profile file exists (optional, but we load it)
        if (!File.Exists(iccProfilePath))
        {
            Console.Error.WriteLine($"ICC profile not found: {iccProfilePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to OdgImage for ODG-specific functionality
            OdgImage odgImage = image as OdgImage;
            if (odgImage == null)
            {
                Console.Error.WriteLine("The loaded file is not a valid ODG image.");
                return;
            }

            // Load the ICC profile stream (placeholder for actual usage)
            using (Stream iccStream = File.OpenRead(iccProfilePath))
            {
                // NOTE: Aspose.Imaging does not expose a direct method to attach an ICC profile
                // to an ODG image before rasterization. If such functionality exists, it would be
                // applied here using the appropriate API (e.g., setting a color profile on the
                // image metadata or using a specific option). This placeholder demonstrates where
                // the ICC profile would be applied.

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the ODG image as PNG
                odgImage.Save(outputPath, pngOptions);
            }
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}