using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (BmpImage bmp = new BmpImage(inputPath))
            {
                // Invert colors pixel by pixel
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        var pixel = bmp.GetPixel(x, y);
                        var inverted = Color.FromArgb(
                            255,
                            255 - pixel.R,
                            255 - pixel.G,
                            255 - pixel.B);
                        bmp.SetPixel(x, y, inverted);
                    }
                }

                // Save the inverted image into a PDF file
                var pdfOptions = new PdfOptions();
                bmp.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}