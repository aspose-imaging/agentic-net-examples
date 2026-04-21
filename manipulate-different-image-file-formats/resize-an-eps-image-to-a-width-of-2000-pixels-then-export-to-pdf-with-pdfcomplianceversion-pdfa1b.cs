using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image, resize it, and save as PDF/A-1b
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Calculate new height to preserve aspect ratio when width is set to 2000 pixels
            int newWidth = 2000;
            int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

            // Resize the image (using default nearest-neighbour resampling)
            image.Resize(newWidth, newHeight);

            // Prepare PDF options with PDF/A-1b compliance
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the resized image as a PDF file
            image.Save(outputPath, pdfOptions);
        }
    }
}