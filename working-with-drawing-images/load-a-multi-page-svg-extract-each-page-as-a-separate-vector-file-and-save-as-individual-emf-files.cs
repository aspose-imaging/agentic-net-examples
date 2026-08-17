// HOW-TO: Extract Each Page From Multi‑Page SVG and Save as EMF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = @"C:\Temp\multpage.svg";
        string outputDirectory = @"C:\Temp\Output";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates even if null)
        Directory.CreateDirectory(outputDirectory);

        try
        {
            // Load the SVG (or any vector image) using the unified loader
            using (Image image = Image.Load(inputPath))
            {
                // Determine if the image supports multiple pages
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage?.PageCount ?? 1; // fallback to 1 for single‑page images

                for (int i = 0; i < pageCount; i++)
                {
                    // Build a distinct output file name for each page
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.emf");

                    // Ensure the directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Prepare EMF save options with vector rasterization settings
                    var emfOptions = new EmfOptions
                    {
                        // Preserve the original page size
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            PageSize = image.Size
                        },

                        // Export only the current page
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                    };

                    // Save the current page as an EMF file
                    image.Save(outputPath, emfOptions);
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
 * 1. When you need to convert a multi‑page SVG diagram into separate EMF files for use in Microsoft Office documents.
 * 2. When you want to programmatically split a vector graphic into individual pages to edit or print each page separately.
 * 3. When an application must generate high‑quality vector thumbnails for each page of an SVG for a web preview gallery.
 * 4. When a reporting tool requires each SVG page as an EMF vector to preserve scalability in PDF or XPS exports.
 * 5. When automating batch processing of SVG assets to create page‑by‑page EMF resources for a CAD workflow.
 */
