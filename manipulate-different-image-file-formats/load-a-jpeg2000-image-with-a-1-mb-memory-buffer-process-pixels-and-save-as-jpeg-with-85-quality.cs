using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
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

        // Load JPEG2000 image with a 1 MB buffer hint
        LoadOptions loadOptions = new LoadOptions { BufferSizeHint = 1 * 1024 * 1024 };
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Cast to RasterImage for pixel manipulation
            RasterImage raster = (RasterImage)image;

            int width = raster.Width;
            int height = raster.Height;
            int[] pixels = new int[width * height];

            // Retrieve ARGB pixel data
            Rectangle fullRect = new Rectangle(0, 0, width, height);
            raster.SaveArgb32Pixels(fullRect, pixels);

            // Simple pixel processing: invert RGB channels while preserving alpha
            for (int i = 0; i < pixels.Length; i++)
            {
                int argb = pixels[i];
                int alpha = argb & unchecked((int)0xFF000000);
                int rgb = argb & 0x00FFFFFF;
                rgb = (~rgb) & 0x00FFFFFF;
                pixels[i] = alpha | rgb;
            }

            // Write modified pixels back to the image
            raster.SaveArgb32Pixels(fullRect, pixels);

            // Prepare JPEG save options with 85% quality
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 85,
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the processed image as JPEG
            raster.Save(outputPath, jpegOptions);
        }
    }
}