using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Create a simple palette with a few colors
                var palette = new Aspose.Imaging.ColorPalette(new Aspose.Imaging.Color[]
                {
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Green,
                    Aspose.Imaging.Color.Blue,
                    Aspose.Imaging.Color.White
                });

                // Set the palette in APNG options
                ApngOptions apngOptions = new ApngOptions
                {
                    Palette = palette
                };

                // Save the modified animation as APNG
                image.Save(outputPath, apngOptions);
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
 * 1. When a developer needs to convert an animated WEBP file to an APNG while applying a custom color palette for reduced file size and consistent branding.
 * 2. When a mobile app requires animated graphics in APNG format instead of WEBP to support iOS devices, and the developer wants to adjust the colors programmatically using C# and Aspose.Imaging.
 * 3. When a web designer wants to replace the original colors of an animated WEBP with a limited set of brand colors before publishing the animation as an APNG on a website.
 * 4. When a game developer must preprocess animated assets by loading a WEBP animation, applying a predefined palette, and exporting it as an APNG for use in a cross‑platform engine.
 * 5. When an automated build pipeline needs to validate the existence of an animated WEBP, transform its palette, and generate an APNG output as part of a continuous‑integration image processing step.
 */