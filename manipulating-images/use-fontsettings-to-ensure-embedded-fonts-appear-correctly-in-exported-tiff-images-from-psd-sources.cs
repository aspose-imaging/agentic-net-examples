using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/sample.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Aspose.Imaging.FontSettings.SetFontsFolders(new string[] { "Fonts" }, false);

            using (Aspose.Imaging.Image psdImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputPath, false),
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                psdImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert Photoshop PSD files that contain text layers with custom fonts into high‑resolution TIFF images for print‑ready output, ensuring the embedded fonts are rendered correctly using Aspose.Imaging FontSettings.
 * 2. When an automated workflow must generate archival TIFF copies of design assets from PSD sources while preserving exact font appearance for legal or compliance documentation.
 * 3. When a web service processes user‑uploaded PSD files and returns TIFF previews that display the original typography, requiring explicit font folder configuration in C#.
 * 4. When a desktop application batch‑converts a library of PSD graphics to TIFF for integration into a digital asset management system, and the fonts are stored in a non‑standard directory.
 * 5. When a CI/CD pipeline validates that PSD files used in marketing campaigns render correctly as TIFFs on downstream systems by loading custom fonts via Aspose.Imaging FontSettings before saving.
 */