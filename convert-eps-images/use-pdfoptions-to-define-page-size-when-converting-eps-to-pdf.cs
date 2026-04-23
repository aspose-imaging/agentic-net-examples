using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = Path.Combine("Input", "sample.eps");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image and convert to PDF with page size defined
        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            var pdfOptions = new PdfOptions
            {
                // Set PDF page size to match EPS dimensions
                PageSize = new SizeF(epsImage.Width, epsImage.Height)
            };

            epsImage.Save(outputPath, pdfOptions);
        }
    }
}