using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample.pdf";

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
            // Load the CMX image with default load options
            using (Image image = Image.Load(inputPath, new CmxLoadOptions()))
            {
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Configure rasterization options specific for CMX
                pdfOptions.VectorRasterizationOptions = new CmxRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                // Save the image as PDF; fonts are embedded as subsets by default
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
 * 1. When a print shop needs to archive legacy CorelDRAW CMX artwork as searchable PDF files while keeping the file size small by embedding only the used characters of the fonts.
 * 2. When a document management system must ingest CMX drawings and convert them to PDF for consistent viewing across browsers and mobile devices, using C# and Aspose.Imaging to embed font subsets automatically.
 * 3. When an engineering firm wants to generate PDF reports from CMX schematics on a server‑side .NET application, ensuring that the PDFs contain the exact text appearance without requiring the original fonts on the client side.
 * 4. When a legal compliance workflow requires converting CMX marketing assets to PDF with embedded font subsets to meet e‑discovery standards and preserve document fidelity.
 * 5. When an automated batch process in a Windows environment must convert dozens of CMX files to PDF using a C# script, leveraging Aspose.Imaging to rasterize vector data and embed only the necessary glyphs for faster uploads.
 */