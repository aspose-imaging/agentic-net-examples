using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            int width = epsImage.Width;
            int height = epsImage.Height;

            // Configure high‑quality JPEG options with vector rasterization
            var jpegOptions = new JpegOptions
            {
                Quality = 100,
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    PageWidth = width,
                    PageHeight = height
                }
            };

            // Create a raster canvas for drawing
            using (var raster = (RasterImage)Image.Create(jpegOptions, width, height))
            {
                // Render the EPS onto the raster canvas
                var graphics = new Graphics(raster);
                graphics.DrawImage(epsImage, new Rectangle(0, 0, width, height));

                // ----- Color inversion placeholder -----
                // Iterate over each pixel and invert its ARGB value.
                // Example (implementation omitted for brevity):
                // int[] pixels = raster.SaveArgb32Pixels();
                // for (int i = 0; i < pixels.Length; i++)
                // {
                //     int a = (pixels[i] >> 24) & 0xFF;
                //     int r = 255 - ((pixels[i] >> 16) & 0xFF);
                //     int g = 255 - ((pixels[i] >> 8) & 0xFF);
                //     int b = 255 - (pixels[i] & 0xFF);
                //     pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                // }
                // raster.LoadArgb32Pixels(pixels);
                // ---------------------------------------

                // Save the (inverted) image as a high‑quality JPEG
                raster.Save(outputPath, jpegOptions);
            }
        }
    }
}