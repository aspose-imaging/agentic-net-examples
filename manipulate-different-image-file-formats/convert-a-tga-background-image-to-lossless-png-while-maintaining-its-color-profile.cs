using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tga";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Prepare PNG save options to keep metadata (color profile)
                var pngOptions = new PngOptions
                {
                    KeepMetadata = true
                };

                // Save as lossless PNG
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
 * 1. When a game developer needs to convert legacy TGA textures to lossless PNG files for modern engines while preserving the original color profile.
 * 2. When a digital archivist wants to migrate TGA screenshots from an old graphics pipeline into PNG format for long‑term storage without losing color accuracy.
 * 3. When a web application processes user‑uploaded TGA assets and must output PNG images that retain embedded ICC profiles for consistent display across browsers.
 * 4. When a batch‑processing tool in C# must ensure that converted PNG files keep metadata such as color space, enabling accurate printing of graphics originally saved as TGA.
 * 5. When a CI/CD pipeline validates that image assets are stored in a lossless, web‑friendly format, converting TGA files to PNG while preserving their color profiles using Aspose.Imaging.
 */