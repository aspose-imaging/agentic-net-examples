using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output/inverted.pdf";

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
                    Aspose.Imaging.Color original = bmp.GetPixel(x, y);
                    Aspose.Imaging.Color inverted = Aspose.Imaging.Color.FromArgb(
                        original.A,
                        255 - original.R,
                        255 - original.G,
                        255 - original.B);
                    bmp.SetPixel(x, y, inverted);
                }
            }

            // Save the inverted image as a PDF
            bmp.Save(outputPath, new PdfOptions());
        }
    }
}