// HOW-TO: Convert CDR to PSD with 300 DPI Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.cdr";
        string outputPath = "output.psd";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Configure PSD save options with 300 DPI resolution
                PsdOptions psdOptions = new PsdOptions
                {
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save as PSD with the specified options
                cdr.Save(outputPath, psdOptions);
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
 * 1. When you need to export a CorelDRAW (CDR) design to a Photoshop PSD file for print production, setting the resolution to 300 DPI ensures high‑quality output.
 * 2. When automating a workflow that converts client‑provided CDR artwork into PSDs for a pre‑press pipeline, you must preserve print‑ready resolution.
 * 3. When integrating Aspose.Imaging into a C# application that generates marketing materials, you may need to convert vector CDR files to raster PSDs at 300 DPI for accurate color and detail.
 * 4. When creating a batch conversion tool for a design agency, specifying 300 DPI in the PSD options guarantees that all converted files meet standard print specifications.
 * 5. When developing a server‑side service that receives CDR files and returns PSDs for downstream editing, setting the resolution to 300 DPI avoids scaling issues in Photoshop.
 */
