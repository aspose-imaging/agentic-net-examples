using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to BmpImage for pixel access
                BmpImage bmp = (BmpImage)image;

                // Determine the border color (assume top-left pixel)
                var borderColor = bmp.GetPixel(0, 0);

                int left = 0, right = bmp.Width - 1;
                int top = 0, bottom = bmp.Height - 1;

                // Find left border
                for (int x = 0; x < bmp.Width; x++)
                {
                    bool columnIsBorder = true;
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        if (bmp.GetPixel(x, y) != borderColor)
                        {
                            columnIsBorder = false;
                            break;
                        }
                    }
                    if (!columnIsBorder)
                    {
                        left = x;
                        break;
                    }
                }

                // Find right border
                for (int x = bmp.Width - 1; x >= 0; x--)
                {
                    bool columnIsBorder = true;
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        if (bmp.GetPixel(x, y) != borderColor)
                        {
                            columnIsBorder = false;
                            break;
                        }
                    }
                    if (!columnIsBorder)
                    {
                        right = x;
                        break;
                    }
                }

                // Find top border
                for (int y = 0; y < bmp.Height; y++)
                {
                    bool rowIsBorder = true;
                    for (int x = left; x <= right; x++)
                    {
                        if (bmp.GetPixel(x, y) != borderColor)
                        {
                            rowIsBorder = false;
                            break;
                        }
                    }
                    if (!rowIsBorder)
                    {
                        top = y;
                        break;
                    }
                }

                // Find bottom border
                for (int y = bmp.Height - 1; y >= 0; y--)
                {
                    bool rowIsBorder = true;
                    for (int x = left; x <= right; x++)
                    {
                        if (bmp.GetPixel(x, y) != borderColor)
                        {
                            rowIsBorder = false;
                            break;
                        }
                    }
                    if (!rowIsBorder)
                    {
                        bottom = y;
                        break;
                    }
                }

                // Compute the cropping rectangle
                int cropWidth = right - left + 1;
                int cropHeight = bottom - top + 1;
                var cropRect = new Rectangle(left, top, cropWidth, cropHeight);

                // Crop the image if needed
                if (cropRect.X > 0 || cropRect.Y > 0 || cropRect.Width < bmp.Width || cropRect.Height < bmp.Height)
                {
                    bmp.Crop(cropRect);
                }

                // Save the processed image
                bmp.Save(outputPath, new BmpOptions());
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
 * 1. When a C# application needs to preprocess scanned BMP documents that contain uniform white margins before applying OCR, the code can automatically detect and trim those solid color borders using Aspose.Imaging.
 * 2. When a game development tool imports BMP sprite sheets with a constant background color around each sprite, this snippet removes the surrounding border so the sprites can be packed tightly without extra padding.
 * 3. When a batch image conversion utility must convert legacy BMP files to PNG but first eliminate unwanted black frames that were added during scanning, the border‑removal logic ensures only the actual image content is retained.
 * 4. When a medical imaging system receives BMP scans with a fixed gray border added by the acquisition device, the code strips the border to improve downstream analysis such as segmentation or measurement.
 * 5. When an automated reporting service generates BMP charts that include a solid color margin for layout purposes, this routine trims the margin before embedding the chart into PDF or HTML reports.
 */