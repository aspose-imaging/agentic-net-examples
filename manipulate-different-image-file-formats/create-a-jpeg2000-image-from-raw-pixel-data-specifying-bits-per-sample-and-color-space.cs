using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define image dimensions and bits per pixel
            int width = 200;
            int height = 100;
            int bitsPerPixel = 8; // bits per sample

            // Create a raster image (PNG format) as a canvas for raw pixel data
            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(new PngOptions(), width, height))
            {
                // Fill the raster with a solid color
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(raster);
                SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue);
                graphics.FillRectangle(brush, raster.Bounds);

                // Create a JPEG2000 image from the raster, specifying bits per pixel
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(raster, bitsPerPixel))
                {
                    // Configure JPEG2000 save options (e.g., codec)
                    Jpeg2000Options saveOptions = new Jpeg2000Options
                    {
                        Codec = Jpeg2000Codec.J2K // raw codestream container
                    };

                    // Output path (ensure directory exists)
                    string outputPath = "output\\sample.j2k";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the JPEG2000 image
                    jpeg2000Image.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}