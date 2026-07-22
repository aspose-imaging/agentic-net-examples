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
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Color borderColor = image.GetPixel(0, 0);

                int left = 0, right = 0, top = 0, bottom = 0;
                int width = image.Width;
                int height = image.Height;

                for (int x = 0; x < width; x++)
                {
                    bool columnHasDifferent = false;
                    for (int y = 0; y < height; y++)
                    {
                        if (image.GetPixel(x, y) != borderColor)
                        {
                            columnHasDifferent = true;
                            break;
                        }
                    }
                    if (columnHasDifferent)
                    {
                        left = x;
                        break;
                    }
                }

                for (int x = width - 1; x >= 0; x--)
                {
                    bool columnHasDifferent = false;
                    for (int y = 0; y < height; y++)
                    {
                        if (image.GetPixel(x, y) != borderColor)
                        {
                            columnHasDifferent = true;
                            break;
                        }
                    }
                    if (columnHasDifferent)
                    {
                        right = width - 1 - x;
                        break;
                    }
                }

                for (int y = 0; y < height; y++)
                {
                    bool rowHasDifferent = false;
                    for (int x = 0; x < width; x++)
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

                for (int y = height - 1; y >= 0; y--)
                {
                    bool rowHasDifferent = false;
                    for (int x = 0; x < width; x++)
                    {
                        if (image.GetPixel(x, y) != borderColor)
                        {
                            rowHasDifferent = true;
                            break;
                        }
                    }
                    if (rowHasDifferent)
                    {
                        bottom = height - 1 - y;
                        break;
                    }
                }

                int newWidth = width - left - right;
                int newHeight = height - top - bottom;

                if (newWidth <= 0 || newHeight <= 0)
                {
                    Console.Error.WriteLine("Unable to detect non‑border area.");
                    return;
                }

                var cropArea = new Rectangle(left, top, newWidth, newHeight);
                image.Crop(cropArea);

                var bmpOptions = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer receives scanned BMP documents that contain a uniform white margin, this code can automatically detect and trim the border before performing OCR or archival processing.
 * 2. When an image processing pipeline generates thumbnails from BMP screenshots with a solid black frame, the routine can remove the frame so the thumbnail displays only the relevant content.
 * 3. When a game asset pipeline imports BMP sprite sheets that include a consistent background color border, the code can strip the border to ensure sprites align correctly in the engine.
 * 4. When a batch conversion tool transforms BMP images to PNG for web delivery, removing any solid color border first prevents extra whitespace and reduces the final file size.
 * 5. When a machine‑learning model for visual inspection receives BMP images padded with a colored border added by a camera, this code can crop out the padding so the model trains on the actual subject.
 */