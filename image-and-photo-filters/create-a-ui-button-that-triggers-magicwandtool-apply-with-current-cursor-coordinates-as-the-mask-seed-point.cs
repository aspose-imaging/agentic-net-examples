using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Simulate a UI button press (press Enter to apply the mask)
                Console.WriteLine("Press Enter to apply Magic Wand mask at cursor coordinates.");
                Console.ReadLine();

                // Current cursor coordinates (seed point) – replace with actual values as needed
                int cursorX = 120;
                int cursorY = 100;

                // Create a mask using MagicWandTool and apply it to the image
                MagicWandTool
                    .Select(image, new MagicWandSettings(cursorX, cursorY))
                    .Apply();

                // Save the modified image with PNG options (transparent background)
                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When building a C# Windows Forms photo‑editor that lets users click a “Remove Background” button to instantly apply a Magic Wand selection at the mouse cursor and save the result as a transparent PNG.
 * 2. When creating an image‑annotation tool where a toolbar button triggers MagicWandTool.Apply to highlight a region around the current cursor position for later labeling or cropping.
 * 3. When developing a desktop application that lets users click a “Select Similar Color” button to generate a mask based on the pixel under the cursor, enabling quick isolation of objects in PNG or JPEG files.
 * 4. When implementing a UI for a graphics‑pipeline where a “Apply Mask” button uses the cursor coordinates as the seed point to produce a transparent background for product images before uploading to an e‑commerce site.
 * 5. When adding an interactive “Magic Wand” feature to a C# WPF viewer that, upon button press, creates a mask from the cursor location, applies it to the RasterImage, and saves the edited image with alpha channel support.
 */