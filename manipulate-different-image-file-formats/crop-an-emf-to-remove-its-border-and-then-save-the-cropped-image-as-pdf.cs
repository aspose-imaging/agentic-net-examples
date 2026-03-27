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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access cropping functionality
            EmfImage emfImage = (EmfImage)image;

            // Determine cropping rectangle (remove a 10‑pixel border)
            const int margin = 10;
            var bounds = emfImage.Bounds;
            var cropRect = new Rectangle(
                bounds.X + margin,
                bounds.Y + margin,
                Math.Max(0, bounds.Width - 2 * margin),
                Math.Max(0, bounds.Height - 2 * margin));

            // Crop the image
            emfImage.Crop(cropRect);

            // Save the cropped image as PDF
            emfImage.Save(outputPath, new PdfOptions());
        }
    }
}