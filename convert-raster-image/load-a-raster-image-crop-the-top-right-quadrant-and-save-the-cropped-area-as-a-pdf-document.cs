using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.pdf";

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
                // Cast to RasterImage to access cropping functionality
                RasterImage rasterImage = (RasterImage)image;

                // Define the rectangle for the top‑right quadrant
                int left = rasterImage.Width / 2;
                int top = 0;
                int width = rasterImage.Width - left; // equivalent to rasterImage.Width / 2
                int height = rasterImage.Height / 2;
                Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(left, top, width, height);

                // Crop the image to the defined area
                rasterImage.Crop(cropArea);

                // Set up PDF save options
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