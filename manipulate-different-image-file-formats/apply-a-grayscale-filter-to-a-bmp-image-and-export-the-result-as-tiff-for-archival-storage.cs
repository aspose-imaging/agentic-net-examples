using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = "Input/sample.bmp";
            string outputPath = "Output/sample.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Prepare TIFF options with a bound file source
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.Source = new FileCreateSource(outputPath, false);

                    // Create a TIFF canvas with the same dimensions as the BMP
                    using (Image tiffCanvas = Image.Create(tiffOptions, bmpImage.Width, bmpImage.Height))
                    {
                        // Draw the BMP onto the TIFF canvas
                        Graphics graphics = new Graphics(tiffCanvas);
                        graphics.DrawImage(bmpImage, 0, 0);

                        // Convert the canvas to grayscale
                        TiffImage tiffImage = (TiffImage)tiffCanvas;
                        tiffImage.Grayscale();

                        // Save the TIFF (output path already bound)
                        tiffCanvas.Save();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}