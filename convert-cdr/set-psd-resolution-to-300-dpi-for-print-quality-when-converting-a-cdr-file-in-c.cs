using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cdr";
        string outputPath = "sample_output.psd";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to convert a CorelDRAW (.cdr) illustration to a Photoshop PSD file with 300 DPI resolution for high‑quality print production such as brochures or flyers.
 * 2. When a developer must prepare a vector logo stored in a CDR file for pre‑press by rasterizing it at 300 DPI into a PSD so that printers receive a print‑ready asset.
 * 3. When a developer is building an automated workflow that extracts artwork from legacy CDR files and saves them as 300 DPI PSDs for inclusion in magazine layouts.
 * 4. When a developer wants to archive design assets by converting CDR files to PSD format with 300 DPI resolution to ensure future print fidelity and color consistency.
 * 5. When a developer integrates a C# service that generates print‑ready PSD mockups from CDR source files, requiring a 300 DPI setting to meet industry printing standards.
 */