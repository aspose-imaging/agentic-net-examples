using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\output_cmyk.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Set PSD options with CMYK color mode
                var psdOptions = new PsdOptions
                {
                    ColorMode = ColorModes.Cmyk
                };

                // Save as PSD with CMYK mode
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
 * 1. When a print shop needs to convert vector EPS artwork to a CMYK PSD file for prepress color‑managed workflows using C# and Aspose.Imaging.
 * 2. When a marketing automation system must generate print‑ready PSD files from EPS logos, ensuring the output uses the CMYK color mode required by commercial printers.
 * 3. When a desktop publishing application integrates a feature that transforms incoming EPS illustrations into CMYK PSD layers so designers can edit them in Photoshop before final printing.
 * 4. When a batch processing script in .NET processes a folder of EPS files and saves each as a CMYK PSD to maintain consistent color profiles across all print collateral.
 * 5. When a web service receives EPS uploads and needs to return a CMYK PSD version for clients who require Photoshop‑compatible files for high‑quality offset printing.
 */