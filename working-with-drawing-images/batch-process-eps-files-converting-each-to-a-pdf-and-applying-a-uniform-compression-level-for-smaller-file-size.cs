using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Ensure directories exist
        Directory.CreateDirectory(inputDirectory);
        Directory.CreateDirectory(outputDirectory);

        // Get all EPS files in the input directory
        string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

        foreach (string epsPath in epsFiles)
        {
            // Validate input file existence
            if (!File.Exists(epsPath))
            {
                Console.Error.WriteLine($"File not found: {epsPath}");
                return;
            }

            // Prepare output PDF path
            string outputFileName = Path.GetFileNameWithoutExtension(epsPath) + ".pdf";
            string pdfPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory exists for this file
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Load EPS image and save as PDF
            using (Image image = Image.Load(epsPath))
            {
                var pdfOptions = new PdfOptions();
                image.Save(pdfPath, pdfOptions);
            }
        }
    }
}