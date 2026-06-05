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
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Validate input file existence
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
                int width = image.Width;
                int height = image.Height;

                // Load all pixels as ARGB integers
                int[] pixels = image.LoadArgb32Pixels(new Rectangle(0, 0, width, height));

                // Determine the border color (top-left pixel)
                int borderColor = pixels[0];

                int left = 0, right = 0, top = 0, bottom = 0;

                // Find left border thickness
                while (left < width / 2)
                {
                    bool columnIsBorder = true;
                    for (int y = 0; y < height; y++)
                    {
                        if (pixels[y * width + left] != borderColor)
                        {
                            columnIsBorder = false;
                            break;
                        }
                    }
                    if (!columnIsBorder) break;
                    left++;
                }

                // Find right border thickness
                while (right < width / 2)
                {
                    bool columnIsBorder = true;
                    int colIndex = width - 1 - right;
                    for (int y = 0; y < height; y++)
                    {
                        if (pixels[y * width + colIndex] != borderColor)
                        {
                            columnIsBorder = false;
                            break;
                        }
                    }
                    if (!columnIsBorder) break;
                    right++;
                }

                // Find top border thickness
                while (top < height / 2)
                {
                    bool rowIsBorder = true;
                    for (int x = left; x <= width - right - 1; x++)
                    {
                        if (pixels[top * width + x] != borderColor)
                        {
                            rowIsBorder = false;
                            break;
                        }
                    }
                    if (!rowIsBorder) break;
                    top++;
                }

                // Find bottom border thickness
                while (bottom < height / 2)
                {
                    bool rowIsBorder = true;
                    int y = height - 1 - bottom;
                    for (int x = left; x <= width - right - 1; x++)
                    {
                        if (pixels[y * width + x] != borderColor)
                        {
                            rowIsBorder = false;
                            break;
                        }
                    }
                    if (!rowIsBorder) break;
                    bottom++;
                }

                // Calculate the cropping rectangle
                int newWidth = width - left - right;
                int newHeight = height - top - bottom;
                if (newWidth <= 0 || newHeight <= 0)
                {
                    Console.Error.WriteLine("Unable to detect a valid inner area after border removal.");
                    return;
                }

                var cropRect = new Rectangle(left, top, newWidth, newHeight);
                image.Crop(cropRect);

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

/*
 * Real-World Use Cases:
 * 1. When a developer is importing scanned documents saved as BMP files that contain a uniform white margin, they can use this code to automatically trim the border before OCR processing.
 * 2. When a game asset pipeline receives BMP sprites with a solid background color added by the artist, this routine can strip the colored frame so the sprite blends correctly in the game engine.
 * 3. When a batch conversion tool needs to normalize BMP screenshots that include a black toolbar border, the code can detect and remove the border before converting to PNG.
 * 4. When a medical imaging application receives BMP scans with a fixed gray border added by the scanner hardware, the developer can apply this method to crop the border before performing image analysis.
 * 5. When an archival system stores legacy BMP images with a decorative solid color frame, the code enables automatic border removal to ensure consistent layout when generating thumbnails.
 */