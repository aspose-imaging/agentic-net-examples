using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jp2";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up JPEG2000 load options with a 1 MB buffer hint
            var loadOptions = new Jpeg2000Options
            {
                BufferSizeHint = 1 * 1024 * 1024 // 1 MB
            };

            // Load the JPEG2000 image
            using (var jpeg2000Image = new Jpeg2000Image(inputPath))
            {
                // Example pixel processing: invert colors
                var raster = jpeg2000Image as RasterImage;
                if (raster != null)
                {
                    for (int y = 0; y < raster.Height; y++)
                    {
                        for (int x = 0; x < raster.Width; x++)
                        {
                            var color = raster.GetPixel(x, y);
                            var inverted = Aspose.Imaging.Color.FromArgb(
                                255 - color.R,
                                255 - color.G,
                                255 - color.B);
                            raster.SetPixel(x, y, inverted);
                        }
                    }
                }

                // Prepare JPEG save options with 85% quality
                var jpegOptions = new JpegOptions
                {
                    Quality = 85
                };

                // Save the processed image as JPEG
                jpeg2000Image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}