using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output folder exists (creates it if missing)
            Directory.CreateDirectory(outputFolder);

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output SVG file path, preserving the original filename
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image and convert it to SVG
                using (Image image = Image.Load(inputPath))
                {
                    // Configure SVG rasterization options to match the source image size
                    var vectorOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorOptions,
                        // Keep metadata if needed; can be omitted
                        KeepMetadata = true
                    };

                    // Save the image as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected error messages
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to convert a large collection of PNG icons into scalable SVG graphics for responsive UI design while keeping the original filenames and organizing the results in a dedicated output folder.
 * 2. When a marketing team automates the preparation of high‑resolution PNG product images for vector‑based print catalogs, ensuring each SVG file matches the source size and is saved separately for easy distribution.
 * 3. When a GIS analyst batch processes map tiles stored as PNG files into SVG format to enable lossless scaling in interactive dashboards, preserving file names for seamless data linking.
 * 4. When a mobile app developer migrates legacy PNG assets to SVG to reduce app bundle size and improve rendering on different screen densities, using C# to handle the conversion and store the vectors in a clean output directory.
 * 5. When an e‑learning platform converts course illustration PNGs to SVG for crisp display on any device, maintaining the original naming convention and separating the converted files for version control.
 */