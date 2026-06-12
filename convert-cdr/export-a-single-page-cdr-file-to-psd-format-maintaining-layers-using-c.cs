using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\sample.cdr";
            string outputPath = @"C:\output\sample.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Get the first (and only) page
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

                // Prepare PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Example settings (optional)
                    // CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    // ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
                };

                // Save the page as PSD, preserving layers
                page.Save(outputPath, psdOptions);
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
 * 1. When a graphic designer needs to convert a CorelDRAW (CDR) single‑page illustration to an Adobe Photoshop (PSD) file while preserving editable layers for further editing in Photoshop using C# and Aspose.Imaging.
 * 2. When an automated build pipeline must batch‑process CDR assets and generate PSD files for a marketing team, ensuring layer information is retained through Aspose.Imaging’s C# API.
 * 3. When a web service receives user‑uploaded CDR files and must deliver downloadable PSD versions with intact layers for collaborative design workflows, implemented with C# and Aspose.Imaging.
 * 4. When a legacy desktop application that only supports PSD files needs to import CDR drawings without flattening them, using C# code to load the CDR page and save it as a layered PSD.
 * 5. When a digital asset management system requires programmatic conversion of single‑page CorelDRAW files to PSD format to maintain layer structure for archival and future editing, leveraging Aspose.Imaging for .NET in C#.
 */