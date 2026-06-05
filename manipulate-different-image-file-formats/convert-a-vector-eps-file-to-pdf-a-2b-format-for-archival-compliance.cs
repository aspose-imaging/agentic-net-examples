using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var options = new PdfOptions();
                image.Save(outputPath, options);
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
 * 1. When a publishing company needs to archive legacy vector graphics created in EPS format as PDF/A‑2b compliant files for long‑term preservation, they can use this code to convert the EPS files to PDF/A‑2b in C#.
 * 2. When a legal firm must submit engineering diagrams originally saved as EPS to a court system that only accepts PDF/A‑2b documents, the code enables automated conversion in a .NET application.
 * 3. When a cloud‑based document management system processes user‑uploaded EPS artwork and must store it in a searchable, archival‑ready PDF/A‑2b format, developers can integrate this snippet into the conversion pipeline.
 * 4. When an automated batch job runs nightly to transform a directory of EPS logos into PDF/A‑2b PDFs for inclusion in corporate brand guidelines, this C# example provides the necessary file‑loading and saving logic.
 * 5. When a medical imaging software needs to embed vector EPS charts into PDF/A‑2b reports to meet regulatory compliance, the code offers a straightforward way to perform the conversion within the .NET environment.
 */