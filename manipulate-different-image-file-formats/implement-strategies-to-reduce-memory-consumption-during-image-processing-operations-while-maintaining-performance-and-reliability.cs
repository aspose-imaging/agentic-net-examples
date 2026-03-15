using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Load the source image as a raster image.
        // Using a using block ensures the image is disposed promptly.
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Define tile size for partial processing.
            // Smaller tiles reduce peak memory usage.
            int tileWidth = 1024;
            int tileHeight = 1024;

            int cols = (sourceImage.Width + tileWidth - 1) / tileWidth;
            int rows = (sourceImage.Height + tileHeight - 1) / tileHeight;

            // Create a bound Tiff canvas that writes directly to the output file.
            // This avoids keeping the entire result image in memory.
            Source fileSource = new FileCreateSource(outputPath, false);
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffJpegRgb) { Source = fileSource };
            using (TiffImage canvas = (TiffImage)Image.Create(tiffOptions, sourceImage.Width, sourceImage.Height))
            {
                // Process the image tile by tile.
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        int offsetX = col * tileWidth;
                        int offsetY = row * tileHeight;
                        int currentTileWidth = Math.Min(tileWidth, sourceImage.Width - offsetX);
                        int currentTileHeight = Math.Min(tileHeight, sourceImage.Height - offsetY);

                        // Define the rectangle for the current tile.
                        Rectangle tileRect = new Rectangle(offsetX, offsetY, currentTileWidth, currentTileHeight);

                        // Load only the pixels for this tile.
                        int[] pixels = sourceImage.LoadArgb32Pixels(tileRect);

                        // Example processing: simple brightness boost.
                        // Adjust each pixel without allocating additional large buffers.
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            int argb = pixels[i];
                            int a = (argb >> 24) & 0xFF;
                            int r = (argb >> 16) & 0xFF;
                            int g = (argb >> 8) & 0xFF;
                            int b = argb & 0xFF;

                            // Increase brightness by 10, clamping to 255.
                            r = Math.Min(255, r + 10);
                            g = Math.Min(255, g + 10);
                            b = Math.Min(255, b + 10);

                            pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                        }

                        // Write the processed tile directly to the output canvas.
                        canvas.SaveArgb32Pixels(tileRect, pixels);
                    }
                }

                // Since the canvas was created with a bound FileCreateSource,
                // calling Save() writes the data to the file without loading the whole image into memory.
                canvas.Save();
            }
        }

        // At this point all images and resources have been disposed,
        // minimizing memory footprint while still performing the required processing.
    }
}