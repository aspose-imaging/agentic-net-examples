using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "invertedMask.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using Magic Wand at an example point (100,100)
                var mask = MagicWandTool.Select(image, new MagicWandSettings(100, 100));

                // Invert the mask to select the background
                var invertedMask = mask.Invert();

                // Apply the inverted mask to the image
                invertedMask.ApplyTo(image);

                // Save the resulting image (which now represents the inverted mask) as PNG
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to isolate and export the background of a PNG image as a separate layer for graphic‑design workflows, they can invert a MagicWand selection and save the mask as a PNG with alpha transparency.
 * 2. When building an automated photo‑editing tool that removes unwanted foreground objects, the code can generate an inverted mask to keep only the background and export it for further compositing.
 * 3. When creating a web‑ready image asset where the background must be transparent, a developer can use the MagicWandTool to select a region, invert the mask, and save the result as a Truecolor‑with‑Alpha PNG.
 * 4. When implementing a batch‑processing pipeline that prepares image masks for machine‑learning segmentation, this snippet can invert the initial foreground selection and output the background mask in PNG format.
 * 5. When developing a C# application that needs to generate a printable stencil by selecting the non‑object area of an image, the code can invert the MagicWand mask and export it as a high‑resolution PNG file.
 */