using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, crop the top‑right quadrant, and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access Width, Height and Crop
            RasterImage raster = (RasterImage)image;

            // Define the top‑right quadrant rectangle
            int rectX = raster.Width / 2;
            int rectY = 0;
            int rectWidth = raster.Width - rectX; // same as raster.Width / 2
            int rectHeight = raster.Height / 2;
            Rectangle cropArea = new Rectangle(rectX, rectY, rectWidth, rectHeight);

            // Crop the image
            raster.Crop(cropArea);

            // Save the cropped image as PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}