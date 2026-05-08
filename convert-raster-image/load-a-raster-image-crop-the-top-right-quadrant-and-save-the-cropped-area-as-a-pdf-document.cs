using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Width/Height and Crop
                RasterImage rasterImage = (RasterImage)image;

                // Define the top‑right quadrant rectangle
                int rectX = rasterImage.Width / 2;          // start at middle of width
                int rectY = 0;                              // top edge
                int rectWidth = rasterImage.Width / 2;      // half width
                int rectHeight = rasterImage.Height / 2;    // half height
                Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(rectX, rectY, rectWidth, rectHeight);

                // Crop the image to the defined rectangle
                rasterImage.Crop(cropArea);

                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the cropped image as a PDF document
                rasterImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}