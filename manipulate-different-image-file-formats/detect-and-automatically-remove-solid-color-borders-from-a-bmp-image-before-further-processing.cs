// HOW-TO: Automatically Detect and Remove Solid Color Borders from BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Aspose.Imaging.Color borderColor = image.GetPixel(0, 0);

                int top = 0;
                int bottom = image.Height - 1;
                int left = 0;
                int right = image.Width - 1;

                // Find top boundary
                for (int y = 0; y < image.Height; y++)
                {
                    bool rowHasDifferent = false;
                    for (int x = 0; x < image.Width; x++)
                    {
                        if (image.GetPixel(x, y) != borderColor)
                        {
                            rowHasDifferent = true;
                            break;
                        }
                    }
                    if (rowHasDifferent)
                    {
                        top = y;
                        break;
                    }
                }

                // Find bottom boundary
                for (int y = image.Height - 1; y >= 0; y--)
                {
                    bool rowHasDifferent = false;
                    for (int x = 0; x < image.Width; x++)
                    {
                        if (image.GetPixel(x, y) != borderColor)
                        {
                            rowHasDifferent = true;
                            break;
                        }
                    }
                    if (rowHasDifferent)
                    {
                        bottom = y;
                        break;
                    }
                }

                // Find left boundary
                for (int x = 0; x < image.Width; x++)
                {
                    bool colHasDifferent = false;
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (image.GetPixel(x, y) != borderColor)
                        {
                            colHasDifferent = true;
                            break;
                        }
                    }
                    if (colHasDifferent)
                    {
                        left = x;
                        break;
                    }
                }

                // Find right boundary
                for (int x = image.Width - 1; x >= 0; x--)
                {
                    bool colHasDifferent = false;
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (image.GetPixel(x, y) != borderColor)
                        {
                            colHasDifferent = true;
                            break;
                        }
                    }
                    if (colHasDifferent)
                    {
                        right = x;
                        break;
                    }
                }

                int newWidth = right - left + 1;
                int newHeight = bottom - top + 1;

                if (newWidth <= 0 || newHeight <= 0)
                {
                    Console.Error.WriteLine("Unable to detect content area; image may be uniform.");
                    return;
                }

                image.Crop(new Rectangle(left, top, newWidth, newHeight));

                var saveOptions = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When preparing scanned documents saved as BMP files, you may need to strip uniform color margins before OCR processing.
 * 2. When generating thumbnails from BMP screenshots, removing solid color frames ensures the thumbnail focuses on the actual content.
 * 3. When converting legacy BMP assets to modern formats, eliminating border padding reduces file size and prevents unwanted whitespace.
 * 4. When performing computer-vision analysis on BMP images, discarding constant-color borders improves feature detection accuracy.
 * 5. When batch-processing BMP sprites for a game, automatically cropping identical edge colors simplifies sprite sheet alignment.
 */
