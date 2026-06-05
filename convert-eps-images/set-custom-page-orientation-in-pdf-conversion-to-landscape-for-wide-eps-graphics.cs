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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

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
                // Determine landscape page size (width > height)
                int width = epsImage.Width;
                int height = epsImage.Height;
                if (width < height)
                {
                    // Swap dimensions for landscape orientation
                    int temp = width;
                    width = height;
                    height = temp;
                }

                // Configure PDF options with landscape page size
                var pdfOptions = new PdfOptions
                {
                    PageSize = new SizeF(width, height)
                };

                // Save as PDF with the specified options
                epsImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}