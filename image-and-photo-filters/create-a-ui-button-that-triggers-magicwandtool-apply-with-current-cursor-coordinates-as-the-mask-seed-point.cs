using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int cursorX = 120;
                int cursorY = 100;

                MagicWandTool
                    .Select(image, new MagicWandSettings(cursorX, cursorY))
                    .Apply();

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
 * 1. When building a photo‑editing desktop app that lets users click a “Select Background” button to automatically mask the area under the mouse pointer in a PNG image.
 * 2. When adding an interactive “Remove Object” feature to a C# WPF application that uses the MagicWandTool to create a selection based on the cursor’s X,Y coordinates and then saves the edited image with alpha transparency.
 * 3. When implementing a web‑based image annotation tool in ASP.NET where a toolbar button captures the current mouse position, applies the magic wand selection to a raster PNG, and stores the result for further processing.
 * 4. When creating a batch‑processing utility that lets users preview a mask by clicking a UI button, which runs MagicWandTool.Select on the clicked point and writes the masked PNG to an output folder.
 * 5. When developing a medical imaging viewer that requires a “Select Region of Interest” button to generate a mask from the cursor location on a grayscale PNG and preserve the selection using TruecolorWithAlpha options.
 */