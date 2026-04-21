using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
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
        using (BmpImage bmp = (BmpImage)Image.Load(inputPath))
        {
            // Determine the border color (assume top‑left pixel)
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
                for (int x = 0; x < bmp.Width; x++)
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
                for (int x = 0; x < bmp.Width; x++)
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

            // Crop the image to remove solid borders
            bmp.Crop(cropRect);

            // Save the processed image
            bmp.Save(outputPath);
        }
    }
}