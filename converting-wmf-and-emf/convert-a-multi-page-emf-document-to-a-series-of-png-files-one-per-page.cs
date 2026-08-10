// HOW-TO: Convert Multipage EMF Document to Separate PNG Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Input\MultipageDocument.emf";
        string outputDirectory = @"C:\Output";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Wrap the whole process in a try/catch to handle unexpected errors gracefully
        try
        {
            // Load the EMF document
            using (Image image = Image.Load(inputPath))
            {
                // Prepare base name for output files
                string baseName = Path.GetFileNameWithoutExtension(inputPath);

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(outputDirectory);

                // Try to treat the image as a multipage image
                if (image is IMultipageImage multipage && multipage.PageCount > 1)
                {
                    // Iterate over each page and save it as a separate PNG
                    for (int pageIndex = 0; pageIndex < multipage.PageCount; pageIndex++)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"{baseName}_page{pageIndex + 1}.png");

                        // Ensure the directory for this output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure PNG options with vector rasterization (required for EMF)
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new EmfRasterizationOptions
                            {
                                PageSize = image.Size
                            },
                            // Export only the current page
                            MultiPageOptions = new MultiPageOptions(new IntRange(pageIndex, pageIndex + 1))
                        };

                        // Save the current page as PNG
                        image.Save(outputPath, pngOptions);
                    }
                }
                else
                {
                    // Single‑page EMF: save directly as PNG
                    string outputPath = Path.Combine(outputDirectory, $"{baseName}.png");

                    // Ensure the directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };

                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to extract each page of a vector‑based EMF report as individual PNG images for web preview.
 * 2. When generating thumbnails for every page of a multi‑page EMF diagram to display in a gallery.
 * 3. When converting a multi‑page EMF file into PNGs to feed into a PDF‑creation workflow that only accepts raster images.
 * 4. When automating the batch processing of EMF drawings so each page can be printed or edited in bitmap‑only tools.
 * 5. When preparing separate PNG assets from a multi‑page EMF blueprint for inclusion in a mobile app that cannot render EMF directly.
 */
