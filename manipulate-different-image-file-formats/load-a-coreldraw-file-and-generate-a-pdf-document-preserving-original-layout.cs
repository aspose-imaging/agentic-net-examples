using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Input\sample.cdr";
        string outputPath = @"C:\Output\sample.cdr.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CorelDRAW (CDR) file
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Configure rasterization options specific for CDR
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as PDF preserving the original layout
                image.Save(outputPath, pdfOptions);
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
 * 1. When a design studio needs to automatically convert client‑supplied CorelDRAW (CDR) artwork into print‑ready PDF files while preserving the original layout, this C# code with Aspose.Imaging provides a seamless solution.
 * 2. When a web application must generate downloadable PDF previews of CDR logos or brochures on the fly without installing CorelDRAW, developers can use this snippet to perform server‑side conversion.
 * 3. When an enterprise document‑management system has to archive legacy CDR drawings as searchable PDFs, the code enables rasterization of vector content while maintaining exact positioning.
 * 4. When a batch‑processing tool needs to convert a folder of CorelDRAW files to PDFs for mass mailing or e‑catalog generation, this example supplies the core conversion logic in .NET.
 * 5. When a quality‑control workflow requires comparing the visual fidelity of original CDR designs against their PDF exports, developers can programmatically render the CDR file and save it as a PDF with layout preservation.
 */