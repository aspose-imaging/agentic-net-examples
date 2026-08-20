// HOW-TO: Convert Multipage EPS to Multipage PSD in C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/multipage.eps";
        string outputPath = "Output/multipage.psd";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD export options
                using (var exportOptions = new PsdOptions())
                {
                    // Set multipage options to include all pages
                    if (image is IMultipageImage multipageImage && multipageImage.PageCount > 0)
                    {
                        exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipageImage.PageCount));
                    }

                    // Configure vector rasterization for EPS (vector) images
                    if (image is VectorImage)
                    {
                        exportOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };
                    }

                    // Save as multipage PSD
                    image.Save(outputPath, exportOptions);
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
 * 1. When you need to import a multi‑page EPS artwork into Photoshop‑compatible PSD files for further editing in a .NET application.
 * 2. When a printing workflow requires converting each page of a vector EPS brochure into separate layers of a PSD while preserving page order using C#.
 * 3. When automating batch processing of design assets, you must transform EPS files with multiple pages into multipage PSDs to maintain editability across all pages.
 * 4. When integrating vector graphics into a digital asset management system, you need to rasterize EPS pages to PSD format with a white background via Aspose.Imaging in C#.
 * 5. When generating preview files for a multi‑page EPS catalog, you need to programmatically save all pages as a single PSD document for easy viewing in Photoshop.
 */
