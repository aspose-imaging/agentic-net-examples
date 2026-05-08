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
        string inputPath = "input.emf";
        string outputPath = "output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                EmfImage emf = img as EmfImage;
                if (emf == null)
                {
                    Console.Error.WriteLine("Loaded image is not an EMF image.");
                    return;
                }

                int border = 10;
                int newWidth = emf.Width - 2 * border;
                int newHeight = emf.Height - 2 * border;
                if (newWidth <= 0 || newHeight <= 0)
                {
                    Console.Error.WriteLine("Border too large for image dimensions.");
                    return;
                }

                var cropRect = new Rectangle(border, border, newWidth, newHeight);
                emf.Crop(cropRect);

                PdfOptions pdfOptions = new PdfOptions();
                emf.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}