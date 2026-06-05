using System;
using System.IO;
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputEps";
            string outputFolder = @"C:\OutputPdf";

            // List of EPS files to convert (file names only)
            string[] epsFiles = new[]
            {
                "sample1.eps",
                "sample2.eps",
                "sample3.eps"
            };

            foreach (var fileName in epsFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputFolder, fileName);
                string outputPath = Path.Combine(outputFolder, Path.ChangeExtension(fileName, ".pdf"));

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image and convert to PDF
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions
                        {
                            PdfCompliance = PdfComplianceVersion.PdfA1b
                        }
                    };

                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}