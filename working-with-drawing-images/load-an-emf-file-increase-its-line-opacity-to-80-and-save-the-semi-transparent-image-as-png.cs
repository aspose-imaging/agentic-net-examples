using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Rasterize EMF to a temporary PNG
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    // Use a transparent background to keep original colors
                    BackgroundColor = Color.Transparent
                }
            };
            emfImage.Save(tempPngPath, pngOptions);

            // Load the rasterized PNG to adjust opacity
            using (RasterImage pngImage = (RasterImage)Image.Load(tempPngPath))
            {
                // Iterate over each pixel and set its alpha to 80% of the original
                for (int y = 0; y < pngImage.Height; y++)
                {
                    for (int x = 0; x < pngImage.Width; x++)
                    {
                        Color pixel = pngImage.GetPixel(x, y);
                        byte newAlpha = (byte)(pixel.A * 0.8);
                        Color newPixel = Color.FromArgb(newAlpha, pixel.R, pixel.G, pixel.B);
                        pngImage.SetPixel(x, y, newPixel);
                    }
                }

                // Save the final PNG with adjusted opacity
                pngImage.Save(outputPath);
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
    }
}