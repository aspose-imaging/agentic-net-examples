using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Load all pixels as ARGB32 integers
                var fullRect = new Rectangle(0, 0, image.Width, image.Height);
                int[] pixels = image.LoadArgb32Pixels(fullRect);
                int width = image.Width;
                int height = image.Height;

                // Assume the border color is the color of the top‑left pixel
                int borderColor = pixels[0];

                // Determine the bounding rectangle of non‑border pixels
                int minX = width - 1, maxX = 0, minY = height - 1, maxY = 0;
                bool found = false;

                for (int y = 0; y < height; y++)
                {
                    int rowOffset = y * width;
                    for (int x = 0; x < width; x++)
                    {
                        if (pixels[rowOffset + x] != borderColor)
                        {
                            if (x < minX) minX = x;
                            if (x > maxX) maxX = x;
                            if (y < minY) minY = y;
                            if (y > maxY) maxY = y;
                            found = true;
                        }
                    }
                }

                // If non‑border pixels were found, crop to the bounding rectangle
                if (found)
                {
                    int cropWidth = maxX - minX + 1;
                    int cropHeight = maxY - minY + 1;
                    var cropRect = new Rectangle(minX, minY, cropWidth, cropHeight);
                    image.Crop(cropRect);
                }

                // Save the cropped image as BMP
                var bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}