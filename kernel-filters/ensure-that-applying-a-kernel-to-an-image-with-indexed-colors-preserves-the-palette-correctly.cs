using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Filters;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.bmp";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = @"c:\temp\output.bmp";
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel manipulation
            RasterImage raster = (RasterImage)image;

            // Preserve the original palette if the image uses one
            IColorPalette originalPalette = null;
            if (image.UsePalette)
            {
                originalPalette = raster.Palette;
            }

            // Define a simple sharpening kernel
            float[,] kernel = new float[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Apply the convolution filter
            raster.ApplyFilter(new ConvolutionFilter(kernel));

            // Reapply the original palette to keep indexed colors consistent
            if (originalPalette != null)
            {
                // For BMP images we can set the palette directly
                if (image is BmpImage bmpImg)
                {
                    bmpImg.SetPalette(originalPalette, false);
                }
                else
                {
                    // For other formats, save with explicit palette options
                    BmpOptions saveOptions = new BmpOptions
                    {
                        BitsPerPixel = 8,
                        Palette = originalPalette
                    };
                    image.Save(outputPath, saveOptions);
                    return;
                }
            }

            // Save the processed image
            image.Save(outputPath);
        }
    }
}