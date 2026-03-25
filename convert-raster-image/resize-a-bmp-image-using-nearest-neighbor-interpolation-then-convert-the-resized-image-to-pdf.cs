using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string resizedBmpPath = @"C:\Images\output_resized.bmp";
        string resizedPdfPath = @"C:\Images\output_resized.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(resizedBmpPath));
        Directory.CreateDirectory(Path.GetDirectoryName(resizedPdfPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Determine new dimensions (example: halve the size)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize using the default NearestNeighbourResample interpolation
            image.Resize(newWidth, newHeight);

            // Save the resized image as BMP
            image.Save(resizedBmpPath, new BmpOptions());

            // Convert and save the resized image as PDF
            image.Save(resizedPdfPath, new PdfOptions());
        }
    }
}