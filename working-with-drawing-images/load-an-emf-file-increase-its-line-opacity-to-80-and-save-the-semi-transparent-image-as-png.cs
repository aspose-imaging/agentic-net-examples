using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Rasterize EMF to PNG with default options
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = ((EmfImage)image).Size,
                    // Optional: set background to transparent to keep only drawing
                    BackgroundColor = Color.Transparent
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save rasterized PNG to a memory stream first
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized PNG for pixel manipulation
                    using (PngImage pngImage = (PngImage)Image.Load(ms))
                    {
                        // Adjust opacity of each pixel to 80%
                        // 80% of 255 ≈ 204
                        const byte targetAlpha = 204;

                        for (int y = 0; y < pngImage.Height; y++)
                        {
                            for (int x = 0; x < pngImage.Width; x++)
                            {
                                Color pixel = pngImage.GetPixel(x, y);
                                // Preserve original RGB, set new alpha
                                Color newPixel = Color.FromArgb(targetAlpha, pixel.R, pixel.G, pixel.B);
                                pngImage.SetPixel(x, y, newPixel);
                            }
                        }

                        // Save the final PNG with adjusted opacity
                        pngImage.Save(outputPath);
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