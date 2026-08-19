// HOW-TO: Export CDR to PSD with Layer Groups Preserved in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access vector-specific properties
                CdrImage cdrImage = (CdrImage)image;

                // Prepare PSD export options
                PsdOptions psdOptions = new PsdOptions();

                // Preserve each page as a separate layer in the PSD
                psdOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, cdrImage.PageCount));

                // Set vector rasterization options for proper rendering
                psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cdrImage.Width,
                    PageHeight = cdrImage.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Save the image as PSD with layer preservation
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
 * 1. When you need to convert a CorelDRAW (CDR) design into a Photoshop (PSD) file while keeping each page as an editable layer for further editing.
 * 2. When automating a workflow that extracts vector graphics from CDR files and rasterizes them into PSD layers for batch processing in a .NET application.
 * 3. When preserving the original layer structure of a multi‑page CDR document is required for collaborative design hand‑off between CorelDRAW and Photoshop users.
 * 4. When generating PSD previews of CDR assets on a server, ensuring the background color and text rendering settings match the original design.
 * 5. When integrating Aspose.Imaging into a C# service that converts client‑uploaded CDR files to PSD while maintaining vector quality and separate layers for each page.
 */
