using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 180 degrees
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Prepare PDF export options (portrait orientation is default)
                var pdfOptions = new PdfOptions
                {
                    // Optional: set page size to match the image dimensions
                    PageSize = new SizeF(image.Width, image.Height)
                };

                // Save the rotated image as a PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}