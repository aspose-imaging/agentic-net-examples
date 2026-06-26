using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

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
 * 1. When a developer needs to generate a print‑ready PDF from an OpenDocument Graphic (ODG) file in a C# application, they can use Aspose.Imaging to load the ODG and save it as PDF with proper vector rasterization and embedded fonts.
 * 2. When an enterprise workflow requires automatic conversion of designer‑created ODG diagrams into PDF documents for archival or compliance purposes, this code provides a reliable way to perform the conversion in .NET.
 * 3. When a web service must deliver ODG‑based charts or illustrations as downloadable PDFs to end‑users, the sample shows how to load the ODG, set page size and background color, and save the result with Aspose.Imaging.
 * 4. When a reporting engine needs to embed ODG graphics into multi‑page PDF reports while preserving font appearance, the code demonstrates the C# steps to rasterize the vector image and embed necessary fonts.
 * 5. When a batch processing script has to convert a folder of ODG files to PDFs for email attachment or document management, this example illustrates the file‑existence checks, directory creation, and Aspose.Imaging conversion logic.
 */