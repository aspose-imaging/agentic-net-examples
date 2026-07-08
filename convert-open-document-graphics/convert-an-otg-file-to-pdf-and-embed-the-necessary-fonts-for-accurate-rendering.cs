using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\input\sample.otg";
            string outputPath = @"C:\output\sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG → PDF conversion
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    // Preserve the original page size (aspect ratio)
                    PageSize = image.Size
                };

                // Set up PDF save options and attach the rasterization options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save the image as PDF; fonts are embedded automatically by the rasterizer
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
 * 1. When a developer needs to convert legacy OTG vector graphics from a CAD system into PDF documents for client distribution while preserving exact page dimensions.
 * 2. When an application must generate printable PDFs from OTG files received via an API, ensuring the embedded fonts render correctly on any viewer.
 * 3. When a batch‑processing service automates the transformation of OTG design assets into PDF portfolios for archival in a document management system.
 * 4. When a Windows desktop tool allows users to select an OTG file and instantly save it as a PDF with embedded fonts for accurate on‑screen and printed output.
 * 5. When a server‑side C# service integrates Aspose.Imaging to render OTG diagrams as PDF reports that can be emailed to stakeholders without requiring the original font files.
 */