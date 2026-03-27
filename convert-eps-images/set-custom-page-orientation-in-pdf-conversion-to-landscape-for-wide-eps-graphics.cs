using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\wide.eps";
        string outputPath = "Output\\wide.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            int width = epsImage.Width;
            int height = epsImage.Height;

            // Configure PDF options with landscape page size
            using (var pdfOptions = new PdfOptions())
            {
                // If the EPS is portrait, swap dimensions to force landscape
                if (width < height)
                    pdfOptions.PageSize = new SizeF(height, width);
                else
                    pdfOptions.PageSize = new SizeF(width, height);

                // Save as PDF
                epsImage.Save(outputPath, pdfOptions);
            }
        }
    }
}