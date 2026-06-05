using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.pdf";

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
                // Apply color inversion if the image is a raster image
                if (image is RasterImage raster)
                {
                    int width = raster.Width;
                    int height = raster.Height;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // Get current pixel
                            Aspose.Imaging.Color pixel = raster.GetPixel(x, y);

                            // Invert RGB channels (preserve alpha)
                            Aspose.Imaging.Color inverted = Aspose.Imaging.Color.FromArgb(
                                pixel.A,
                                (byte)(255 - pixel.R),
                                (byte)(255 - pixel.G),
                                (byte)(255 - pixel.B));

                            // Set inverted pixel back
                            raster.SetPixel(x, y, inverted);
                        }
                    }
                }

                // Prepare PDF options
                var pdfOptions = new PdfOptions();

                // Save the inverted image as a PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}