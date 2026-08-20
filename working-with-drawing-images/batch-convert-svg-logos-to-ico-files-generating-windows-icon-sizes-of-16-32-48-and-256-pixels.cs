// HOW-TO: Batch Convert SVG Logos to Multi‑Size ICO Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string svgFilePath in svgFiles)
            {
                // Verify the SVG file exists
                if (!File.Exists(svgFilePath))
                {
                    Console.Error.WriteLine($"File not found: {svgFilePath}");
                    return;
                }

                // Prepare output ICO path
                string outputFileName = Path.GetFileNameWithoutExtension(svgFilePath) + ".ico";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(svgFilePath))
                {
                    // Define desired icon sizes
                    int[] iconSizes = new[] { 16, 32, 48, 256 };

                    // Prepare rasterization options for each size
                    VectorRasterizationOptions[] pageOptions = new VectorRasterizationOptions[iconSizes.Length];
                    for (int i = 0; i < iconSizes.Length; i++)
                    {
                        pageOptions[i] = new VectorRasterizationOptions
                        {
                            PageWidth = iconSizes[i],
                            PageHeight = iconSizes[i],
                            BackgroundColor = Color.White
                        };
                    }

                    // Configure ICO options with multiple pages (sizes)
                    IcoOptions icoOptions = new IcoOptions
                    {
                        MultiPageOptions = new MultiPageOptions
                        {
                            PageRasterizationOptions = pageOptions
                        }
                    };

                    // Save as ICO
                    svgImage.Save(outputPath, icoOptions);
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
 * 1. When you need to generate Windows application icons from a set of SVG brand logos for different DPI settings.
 * 2. When automating the creation of .ico files for a software installer that requires 16‑, 32‑, 48‑ and 256‑pixel versions.
 * 3. When preparing a web‑based asset pipeline that converts designer‑provided SVG icons into Windows‑compatible ICO resources.
 * 4. When updating a legacy desktop application’s icon set without manually resizing each SVG file.
 * 5. When building a CI/CD step that ensures every SVG asset in a repository is available as a multi‑size Windows icon.
 */
