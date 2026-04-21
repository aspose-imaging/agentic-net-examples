using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source PNG image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage source = (RasterImage)image;
            int width = source.Width;
            int height = source.Height;

            // Create a new PNG image to hold the filtered result
            using (PngImage result = new PngImage(width, height))
            {
                // Apply a 5x5 averaging kernel
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int sumA = 0, sumR = 0, sumG = 0, sumB = 0;
                        int count = 0;

                        // Iterate over the 5x5 neighbourhood
                        for (int ky = -2; ky <= 2; ky++)
                        {
                            int ny = y + ky;
                            // Clamp to image borders
                            if (ny < 0) ny = 0;
                            if (ny >= height) ny = height - 1;

                            for (int kx = -2; kx <= 2; kx++)
                            {
                                int nx = x + kx;
                                if (nx < 0) nx = 0;
                                if (nx >= width) nx = width - 1;

                                Color pixel = source.GetPixel(nx, ny);
                                sumA += pixel.A;
                                sumR += pixel.R;
                                sumG += pixel.G;
                                sumB += pixel.B;
                                count++;
                            }
                        }

                        // Compute average color
                        Color avg = Color.FromArgb(
                            sumA / count,
                            sumR / count,
                            sumG / count,
                            sumB / count);

                        result.SetPixel(x, y, avg);
                    }
                }

                // Save the filtered image
                result.Save(outputPath);
            }
        }
    }
}