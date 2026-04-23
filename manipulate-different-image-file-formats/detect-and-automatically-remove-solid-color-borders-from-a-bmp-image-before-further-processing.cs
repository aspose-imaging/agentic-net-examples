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
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                int width = image.Width;
                int height = image.Height;

                Aspose.Imaging.Color borderColor = image.GetPixel(0, 0);

                int leftShift = 0;
                for (int x = 0; x < width; x++)
                {
                    bool columnMatches = true;
                    for (int y = 0; y < height; y++)
                    {
                        if (!image.GetPixel(x, y).Equals(borderColor))
                        {
                            columnMatches = false;
                            break;
                        }
                    }
                    if (!columnMatches)
                    {
                        leftShift = x;
                        break;
                    }
                }

                int rightShift = 0;
                for (int x = width - 1; x >= 0; x--)
                {
                    bool columnMatches = true;
                    for (int y = 0; y < height; y++)
                    {
                        if (!image.GetPixel(x, y).Equals(borderColor))
                        {
                            columnMatches = false;
                            break;
                        }
                    }
                    if (!columnMatches)
                    {
                        rightShift = width - 1 - x;
                        break;
                    }
                }

                int topShift = 0;
                for (int y = 0; y < height; y++)
                {
                    bool rowMatches = true;
                    for (int x = 0; x < width; x++)
                    {
                        if (!image.GetPixel(x, y).Equals(borderColor))
                        {
                            rowMatches = false;
                            break;
                        }
                    }
                    if (!rowMatches)
                    {
                        topShift = y;
                        break;
                    }
                }

                int bottomShift = 0;
                for (int y = height - 1; y >= 0; y--)
                {
                    bool rowMatches = true;
                    for (int x = 0; x < width; x++)
                    {
                        if (!image.GetPixel(x, y).Equals(borderColor))
                        {
                            rowMatches = false;
                            break;
                        }
                    }
                    if (!rowMatches)
                    {
                        bottomShift = height - 1 - y;
                        break;
                    }
                }

                image.Crop(leftShift, rightShift, topShift, bottomShift);

                BmpOptions saveOptions = new BmpOptions();
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}