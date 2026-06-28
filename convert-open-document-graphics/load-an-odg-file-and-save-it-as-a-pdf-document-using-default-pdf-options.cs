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
            // Hardcoded input and output file paths
            string inputPath = "input/input.odg";
            string outputPath = "output/output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for ODG
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options and attach rasterization options
                PdfOptions saveOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the image as PDF
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert OpenDocument graphics (ODG) diagrams created in LibreOffice into PDF files for easy sharing with clients who only have PDF viewers.
 * 2. When an automated reporting system must batch‑process ODG charts and embed them in PDF reports without manually opening each file.
 * 3. When a web application allows users to upload ODG illustrations and instantly provides a downloadable PDF version for printing or archiving.
 * 4. When a document management workflow requires converting ODG assets to PDF to ensure consistent rendering across different operating systems.
 * 5. When a C# desktop tool integrates Aspose.Imaging to rasterize ODG pages with a white background and save them as PDF for inclusion in legal or compliance documentation.
 */