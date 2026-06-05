using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Wrap the whole processing in a try/catch to handle unexpected errors gracefully
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.gif";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific functionality
                GifImage gifImage = (GifImage)image;

                // Deskew the image (normalize angle based on detected skew)
                gifImage.NormalizeAngle();

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette (black & white)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the processed image as PNG
                gifImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Output any error message without crashing the program
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}