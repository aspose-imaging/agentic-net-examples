using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.bmp";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to PngImage to access transparency properties
                if (image is PngImage pngImage)
                {
                    // If the image has transparent pixels, set a solid background color
                    if (pngImage.HasTransparentColor)
                    {
                        pngImage.BackgroundColor = Color.Blue;      // solid background color
                        pngImage.HasBackgroundColor = true;        // enable background replacement
                    }

                    // Save as BMP using default options (transparency handled via background color)
                    pngImage.Save(outputPath, new BmpOptions());
                }
                else
                {
                    // If not a PNG, just save using default BMP options
                    image.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to convert a PNG with an alpha channel into a BMP for legacy Windows applications that do not support transparency, this code replaces transparent pixels with a solid background color.
 * 2. When preparing product screenshots containing transparent overlays for printed documentation, the snippet saves the image as a BMP with a chosen background hue.
 * 3. When integrating an image‑processing pipeline that receives user‑uploaded PNG icons and must store them in a BMP format for a database that only accepts non‑transparent bitmaps, this example shows how to set a background color and save.
 * 4. When automating batch conversion of UI assets from PNG to BMP on a server using C# and Aspose.Imaging, the code ensures transparent areas are filled with a consistent color before saving.
 * 5. When developing a game‑asset tool that needs to export transparent sprites as BMP files for a legacy engine, this code demonstrates how to handle PNG transparency and apply a solid background in .NET.
 */