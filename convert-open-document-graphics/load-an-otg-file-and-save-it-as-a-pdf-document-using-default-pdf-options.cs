using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.otg";
        string outputPath = "Output\\sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    pdfOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When a developer needs to convert legacy OTG vector graphics created by older CAD tools into a universally viewable PDF for client distribution, they can use this code to load the OTG file and save it as a PDF with default options.
 * 2. When building a C# desktop application that generates printable reports from OTG diagrams, the code enables seamless loading of the OTG image and exporting it to PDF for high‑quality printing.
 * 3. When automating a server‑side .NET service to archive engineering drawings, the code can batch‑process OTG files, rasterize them with VectorRasterizationOptions, and store them as PDF documents.
 * 4. When creating marketing brochures that must include vector artwork originally saved as OTG, developers can embed the OTG image into a PDF using Aspose.Imaging’s PdfOptions to retain crisp vector quality.
 * 5. When exposing a web API endpoint that accepts OTG uploads and returns a PDF response, this snippet provides the core logic to load the OTG file, apply default PDF settings, and deliver the resulting PDF to the caller.
 */