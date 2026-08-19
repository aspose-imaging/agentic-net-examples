// HOW-TO: Convert Single Page CDR to Transparent PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Get the first (single) page
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

                // Set PNG options (default preserves transparency)
                PngOptions pngOptions = new PngOptions();

                // Save the page as PNG
                page.Save(outputPath, pngOptions);
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
 * 1. When a designer provides a CorelDRAW (CDR) logo that needs to be displayed on a website with a transparent background, a developer can use this code to convert the single‑page file to a PNG preserving the transparency.
 * 2. When an automated build pipeline must generate thumbnail previews of CDR assets for a digital asset management system, the snippet can convert each CDR page to a transparent PNG for quick preview rendering.
 * 3. When a Windows desktop application imports vector artwork from CorelDRAW and needs to embed it into a PDF or report as a raster image with no background, the code converts the CDR page to PNG while keeping the transparent layers.
 * 4. When a batch‑processing service processes user‑uploaded CDR files and stores them in a cloud storage bucket as web‑ready PNGs, this example shows how to read the file, ensure the output folder exists, and save the transparent PNG.
 * 5. When a migration script moves legacy CDR graphics into a modern content management system that only accepts PNG files, the developer can use this code to reliably convert each single‑page CDR while preserving its alpha channel.
 */
