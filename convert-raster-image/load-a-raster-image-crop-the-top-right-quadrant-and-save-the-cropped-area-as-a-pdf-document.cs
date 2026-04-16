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

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Determine the rectangle for the top‑right quadrant
            int rectX = image.Width / 2;          // start at middle of width
            int rectY = 0;                        // top edge
            int rectWidth = image.Width - rectX;  // right half width
            int rectHeight = image.Height / 2;    // top half height

            var cropArea = new Rectangle(rectX, rectY, rectWidth, rectHeight);

            // Crop the image to the specified rectangle
            image.Crop(cropArea);

            // Prepare PDF save options
            var pdfOptions = new PdfOptions();

            // Save the cropped image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}