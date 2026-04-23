using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input GIF path
            string inputPath = Path.Combine("Input", "sample.gif");
            // Temporary EMF path
            string emfPath = Path.Combine("Output", "temp.emf");
            // Final PDF path
            string pdfPath = Path.Combine("Output", "output.pdf");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(emfPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Load GIF and convert to EMF
            using (Image gifImage = Image.Load(inputPath))
            {
                var emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = gifImage.Size
                    }
                };
                gifImage.Save(emfPath, emfOptions);
            }

            // Load the generated EMF and save as PDF
            using (EmfImage emfImage = (EmfImage)Image.Load(emfPath))
            {
                var pdfOptions = new PdfOptions();
                emfImage.Save(pdfPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}