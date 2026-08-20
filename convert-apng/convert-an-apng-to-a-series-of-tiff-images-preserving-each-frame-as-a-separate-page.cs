// HOW-TO: Convert APNG to Multi‑Page TIFF with Each Frame as Separate Page in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.apng";
            string outputPath = "output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG image
            using (Image apngImage = Image.Load(inputPath))
            {
                // Save all frames as a multi‑page TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                apngImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive animated PNG graphics as a printable multi‑page TIFF document for documentation or record‑keeping.
 * 2. When a web application must transform user‑uploaded APNG stickers into separate TIFF pages for further editing in Photoshop or other raster tools.
 * 3. When a batch process extracts each frame of an animated PNG to create a multi‑page TIFF that can be imported into PDF generators.
 * 4. When a digital asset management system requires converting animated PNG assets into TIFF stacks to support legacy workflows that only handle TIFF files.
 * 5. When a reporting tool needs to display each animation frame on a separate page of a TIFF report generated from APNG sources.
 */
