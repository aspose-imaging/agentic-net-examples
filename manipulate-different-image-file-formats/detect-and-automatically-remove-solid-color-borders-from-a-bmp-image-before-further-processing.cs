// HOW-TO: Automatically Trim Solid Color Borders from BMP Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
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
                // Assume the border color is the pixel at (0,0)
                Color borderColor = image.GetPixel(0, 0);

                int left = 0;
                int right = image.Width - 1;
                int top = 0;
                int bottom = image.Height - 1;

                // Find left border
                for (left = 0; left < image.Width; left++)
                {
                    bool columnUniform = true;
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (image.GetPixel(left, y) != borderColor)
                        {
                            columnUniform = false;
                            break;
                        }
                    }
                    if (!columnUniform) break;
                }

                // Find right border
                for (right = image.Width - 1; right >= 0; right--)
                {
                    bool columnUniform = true;
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (image.GetPixel(right, y) != borderColor)
                        {
                            columnUniform = false;
                            break;
                        }
                    }
                    if (!columnUniform) break;
                }

                // Find top border
                for (top = 0; top < image.Height; top++)
                {
                    bool rowUniform = true;
                    for (int x = left; x <= right; x++)
                    {
                        if (image.GetPixel(x, top) != borderColor)
                        {
                            rowUniform = false;
                            break;
                        }
                    }
                    if (!rowUniform) break;
                }

                // Find bottom border
                for (bottom = image.Height - 1; bottom >= 0; bottom--)
                {
                    bool rowUniform = true;
                    for (int x = left; x <= right; x++)
                    {
                        if (image.GetPixel(x, bottom) != borderColor)
                        {
                            rowUniform = false;
                            break;
                        }
                    }
                    if (!rowUniform) break;
                }

                int newWidth = right - left + 1;
                int newHeight = bottom - top + 1;

                if (newWidth > 0 && newHeight > 0)
                {
                    // Crop the image to remove the solid border
                    var cropRect = new Rectangle(left, top, newWidth, newHeight);
                    image.Crop(cropRect);

                    // Save the cropped image as BMP
                    var bmpOptions = new BmpOptions();
                    image.Save(outputPath, bmpOptions);
                }
                else
                {
                    Console.Error.WriteLine("The image consists entirely of a solid color; nothing to crop.");
                }
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
 * 1. When you receive scanned documents saved as BMP files that include a uniform colored frame, you can use this code to automatically crop the frame before OCR processing.
 * 2. When generating thumbnails from legacy BMP assets that have a solid background border, the snippet removes the border so the thumbnail focuses on the actual content.
 * 3. When preparing BMP images for machine‑learning pipelines, eliminating extraneous solid color edges ensures consistent input dimensions without manual editing.
 * 4. When integrating legacy BMP graphics into a modern UI, the code trims unwanted border pixels so the images align correctly with other UI elements.
 * 5. When batch‑processing BMP screenshots that contain a uniform toolbar border, this routine detects and strips the border to reduce file size and improve visual consistency.
 */
