using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of EPS files to convert
            string[] inputPaths = new[]
            {
                @"C:\Images\Input1.eps",
                @"C:\Images\Input2.eps",
                @"C:\Images\Input3.eps"
            };

            // Process each file in parallel
            Parallel.ForEach(inputPaths, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path (same folder, same name with .pdf)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Set PDF options (optional compliance setting)
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions
                        {
                            PdfCompliance = PdfComplianceVersion.PdfA1b
                        }
                    };

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}