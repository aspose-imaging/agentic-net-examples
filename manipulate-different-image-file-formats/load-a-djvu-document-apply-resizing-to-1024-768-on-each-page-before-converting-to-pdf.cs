using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputPath = @"C:\Temp\Result\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            // Resize each page to 1024x768 using nearest neighbour resampling
            // The Resize method works on the whole multi‑page image
            djvuImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

            // Save the resized document as PDF
            djvuImage.Save(outputPath, new PdfOptions());
        }
    }
}