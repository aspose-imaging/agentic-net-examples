using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with A4 page size
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // A4 size in points (1 point = 1/72 inch)
                    pdfOptions.PageSize = new SizeF(595f, 842f);

                    // Set vector rasterization options for CMX
                    var vectorOptions = new CmxRasterizationOptions
                    {
                        PageSize = new SizeF(595f, 842f),
                        BackgroundColor = Color.White,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        Positioning = PositioningTypes.DefinedByDocument
                    };

                    pdfOptions.VectorRasterizationOptions = vectorOptions;

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When a CAD designer needs to share a Corel Metafile (CMX) drawing with clients who only view PDF documents, they can use this code to convert the CMX file to a PDF with an A4 page layout.
 * 2. When an automated document‑generation pipeline must archive legacy CMX illustrations as printable PDFs, the snippet provides a reliable way to rasterize the vector data and enforce A4 dimensions.
 * 3. When a web service receives CMX uploads and must return a PDF preview that fits standard paper size, developers can call this routine to produce a white‑background PDF using Aspose.Imaging’s PdfOptions.
 * 4. When a batch‑processing job needs to convert a folder of CMX files into A4‑sized PDFs for compliance reporting, the example shows how to load each image, set vector rasterization options, and save the result with C# file‑system checks.
 * 5. When integrating a .NET desktop application that exports technical drawings, this code enables developers to transform a CMX drawing into a PDF ready for printing on A4 paper while preserving vector quality through CmxRasterizationOptions.
 */