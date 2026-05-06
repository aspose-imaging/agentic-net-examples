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
        try
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
                // Set up rasterization options for EMF to PNG conversion
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size
                };

                // PNG save options with vector rasterization
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize EMF to a memory stream first
                using (MemoryStream ms = new MemoryStream())
                {
                    emfImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image (PNG) from the stream
                    using (Image rasterImage = Image.Load(ms))
                    {
                        // Apply sepia tone effect pixel by pixel
                        // Cast to RasterImage to access pixel manipulation methods
                        var raster = rasterImage as Aspose.Imaging.RasterImage;
                        if (raster != null)
                        {
                            for (int y = 0; y < raster.Height; y++)
                            {
                                for (int x = 0; x < raster.Width; x++)
                                {
                                    // Get original pixel color
                                    var originalColor = raster.GetPixel(x, y);
                                    int r = originalColor.R;
                                    int g = originalColor.G;
                                    int b = originalColor.B;

                                    // Compute sepia values
                                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                                    // Clamp to byte range
                                    tr = Math.Min(255, tr);
                                    tg = Math.Min(255, tg);
                                    tb = Math.Min(255, tb);

                                    // Set new pixel color preserving original alpha
                                    var sepiaColor = Aspose.Imaging.Color.FromArgb(originalColor.A, tr, tg, tb);
                                    raster.SetPixel(x, y, sepiaColor);
                                }
                            }
                        }

                        // Save the final PNG with sepia effect
                        rasterImage.Save(outputPath, new PngOptions());
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