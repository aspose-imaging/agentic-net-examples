using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\noisy_input.png";
            string outputPath = @"C:\Images\output\filtered_median.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Keep a copy of the original pixel data for assessment
                int width = rasterImage.Width;
                int height = rasterImage.Height;
                int[,] originalR = new int[width, height];
                int[,] originalG = new int[width, height];
                int[,] originalB = new int[width, height];

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color pixel = rasterImage.GetPixel(x, y);
                        originalR[x, y] = pixel.R;
                        originalG[x, y] = pixel.G;
                        originalB[x, y] = pixel.B;
                    }
                }

                // Apply a median filter with a 5x5 kernel to the entire image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the filtered image
                rasterImage.Save(outputPath);

                // Assess noise reduction effectiveness by computing average absolute difference per channel
                long totalDiff = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color filteredPixel = rasterImage.GetPixel(x, y);
                        totalDiff += Math.Abs(filteredPixel.R - originalR[x, y]);
                        totalDiff += Math.Abs(filteredPixel.G - originalG[x, y]);
                        totalDiff += Math.Abs(filteredPixel.B - originalB[x, y]);
                    }
                }

                double avgDiff = totalDiff / (double)(width * height * 3);
                Console.WriteLine($"Average absolute per‑channel difference after median filtering: {avgDiff:F2}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}