using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.otg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare PNG options with OTG rasterization settings
            var pngOptions = new PngOptions();
            var otgRasterOptions = new Aspose.Imaging.ImageOptions.OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };
            pngOptions.VectorRasterizationOptions = otgRasterOptions;

            // Render OTG to PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                otgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rendered PNG as a raster image for drawing
                using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                {
                    // Create graphics for drawing
                    Graphics graphics = new Graphics(raster);

                    // Define font and brush for the watermark
                    Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 48);
                    using (SolidBrush brush = new SolidBrush())
                    {
                        brush.Color = Aspose.Imaging.Color.Yellow;

                        // Draw watermark text at the bottom-left corner
                        graphics.DrawString("Watermark", font, brush, new Aspose.Imaging.Point(10, raster.Height - 60));
                    }

                    // Save the final PNG with watermark
                    raster.Save(outputPath, pngOptions);
                }
            }
        }
    }
}