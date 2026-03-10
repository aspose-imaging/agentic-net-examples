using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input PNG path and output PDF path as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ImageConversion <input_png_path> <output_pdf_path>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file does not exist: {inputPath}");
                return;
            }

            // Load the high-resolution PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Create PDF options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
                }
            }

            Console.WriteLine($"Converted '{inputPath}' to PDF at '{outputPath}'.");
        }
    }
}