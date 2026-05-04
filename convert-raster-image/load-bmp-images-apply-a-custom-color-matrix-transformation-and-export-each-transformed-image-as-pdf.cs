using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

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
            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.CacheData();

                // Example color matrix: increase red channel by 20%
                float[,] matrix = new float[4, 4]
                {
                    { 1.2f, 0f,   0f,   0f },
                    { 0f,   1f,   0f,   0f },
                    { 0f,   0f,   1f,   0f },
                    { 0f,   0f,   0f,   1f }
                };

                // Retrieve pixel data
                int[] pixels = raster.GetDefaultArgb32Pixels(raster.Bounds);

                // Apply color matrix to each pixel
                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    byte a = (byte)((argb >> 24) & 0xFF);
                    byte r = (byte)((argb >> 16) & 0xFF);
                    byte g = (byte)((argb >> 8) & 0xFF);
                    byte b = (byte)(argb & 0xFF);

                    int newR = (int)(r * matrix[0, 0] + g * matrix[0, 1] + b * matrix[0, 2] + a * matrix[0, 3]);
                    int newG = (int)(r * matrix[1, 0] + g * matrix[1, 1] + b * matrix[1, 2] + a * matrix[1, 3]);
                    int newB = (int)(r * matrix[2, 0] + g * matrix[2, 1] + b * matrix[2, 2] + a * matrix[2, 3]);
                    int newA = (int)(r * matrix[3, 0] + g * matrix[3, 1] + b * matrix[3, 2] + a * matrix[3, 3]);

                    newR = Math.Clamp(newR, 0, 255);
                    newG = Math.Clamp(newG, 0, 255);
                    newB = Math.Clamp(newB, 0, 255);
                    newA = Math.Clamp(newA, 0, 255);

                    pixels[i] = (newA << 24) | (newR << 16) | (newG << 8) | newB;
                }

                // Write transformed pixels back to the image
                raster.SaveArgb32Pixels(raster.Bounds, pixels);

                // Export transformed image as PDF
                raster.Save(outputPath, new PdfOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}