using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Define a crop rectangle that removes a 10‑pixel border from each side
                int margin = 10;
                int cropX = margin;
                int cropY = margin;
                int cropWidth = emfImage.Width - 2 * margin;
                int cropHeight = emfImage.Height - 2 * margin;

                // Guard against invalid dimensions (e.g., very small images)
                if (cropWidth > 0 && cropHeight > 0)
                {
                    var cropRect = new Aspose.Imaging.Rectangle(cropX, cropY, cropWidth, cropHeight);
                    emfImage.Crop(cropRect);
                }

                // Save the cropped image as PDF
                var pdfOptions = new PdfOptions();
                emfImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}