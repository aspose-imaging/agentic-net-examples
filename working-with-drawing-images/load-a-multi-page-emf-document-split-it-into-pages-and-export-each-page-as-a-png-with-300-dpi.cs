// HOW-TO: Split Multi-Page EMF Into 300 DPI PNG Pages In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input EMF file path
            string inputPath = "input.emf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the EMF document
            using (Image image = Image.Load(inputPath))
            {
                // Determine if the image supports multiple pages
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                // Export each page as a PNG with 300 DPI
                for (int i = 0; i < pageCount; i++)
                {
                    // Construct output file path (ensure it contains a directory)
                    string outputDir = "output";
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PNG save options
                    PngOptions pngOptions = new PngOptions
                    {
                        // Set resolution to 300 DPI
                        ResolutionSettings = new ResolutionSetting(300, 300)
                    };

                    // Configure vector rasterization for EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        // Use the original image size for each page
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    // If the source is multipage, limit export to the current page
                    if (multipage != null)
                    {
                        pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));
                    }

                    // Save the current page as PNG
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
 * 1. When you need to convert each page of a vector‑based EMF report into high‑resolution PNG images for web preview.
 * 2. When generating printable thumbnails from a multi‑page EMF diagram at 300 DPI for inclusion in PDF catalogs.
 * 3. When extracting individual pages from a multi‑page EMF file to feed into a machine‑learning model that requires raster images.
 * 4. When automating the creation of separate PNG assets from a multi‑page EMF logo set for use in mobile applications.
 * 5. When preparing 300 DPI PNG copies of each EMF page for archival storage in a document management system.
 */
