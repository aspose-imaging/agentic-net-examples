// HOW-TO: Convert Single Page CDR to PSD with Layers Preserved in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\sample.psd";

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

                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions();

                // Set vector rasterization options to preserve layers and vector data
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions()
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                psdOptions.VectorRasterizationOptions = rasterOptions;

                // Save the page as a PSD file (layers are maintained)
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
 * 1. When you need to bring CorelDRAW artwork into Photoshop while keeping each object as an editable layer.
 * 2. When automating a batch process that converts CDR design files to PSD for a web preview pipeline.
 * 3. When preserving vector text and shapes from a CDR illustration for further editing in Adobe Photoshop via a .NET application.
 * 4. When generating PSD files from CDR templates in a server‑side C# service to create print‑ready proofs.
 * 5. When migrating legacy single‑page CDR graphics to a Photoshop‑compatible format without flattening the artwork.
 */
