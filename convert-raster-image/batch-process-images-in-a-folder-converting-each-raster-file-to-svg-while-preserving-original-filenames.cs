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
            // Hardcoded input and output folders
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output base folder exists
            Directory.CreateDirectory(outputFolder);

            // Define raster image extensions to process
            string[] rasterExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif", ".tiff", ".tif" };

            // Get all files in the input folder
            foreach (string filePath in Directory.GetFiles(inputFolder))
            {
                // Process only supported raster formats
                if (Array.IndexOf(rasterExtensions, Path.GetExtension(filePath).ToLowerInvariant()) < 0)
                    continue;

                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Build output path with .svg extension, preserving original filename
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image and convert to SVG
                using (Image image = Image.Load(filePath))
                {
                    // Set up rasterization options for SVG output
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save the image as SVG using the specified options
                    image.Save(outputPath, new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions
                    });
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
 * 1. When a developer needs to automate the conversion of a large collection of raster images (PNG, JPEG, BMP, GIF, TIFF, etc.) into scalable SVG files while preserving the original filenames for use in responsive web design.
 * 2. When a batch image‑processing pipeline must generate vector graphics from product photos stored in a folder so they can be embedded in marketing PDFs without loss of quality.
 * 3. When a C# application has to prepare assets for a mobile app by converting all bitmap icons in a directory to SVG format to reduce file size and support resolution‑independent rendering.
 * 4. When a software tool needs to migrate legacy scanned documents (TIFF, GIF) to SVG for easier editing in vector editors while preserving the folder structure.
 * 5. When an automated build script must ensure that every raster image in a source folder is exported as an SVG with matching filenames for integration into a design system repository.
 */