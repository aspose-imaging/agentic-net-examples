using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the EMF document
            using (Image image = Image.Load(inputPath))
            {
                // Determine page count
                int pageCount = 1;
                if (image is IMultipageImage multipageImage)
                {
                    pageCount = multipageImage.PageCount;
                }

                // Prepare vector rasterization options if needed
                VectorRasterizationOptions vectorOptions = null;
                if (image is VectorImage)
                {
                    vectorOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                }

                // Export each page as a PNG with 300 DPI
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PNG options
                    PngOptions pngOptions = new PngOptions
                    {
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                    };

                    if (vectorOptions != null)
                    {
                        pngOptions.VectorRasterizationOptions = vectorOptions;
                    }

                    // Save the specific page
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
 * 1. When a developer needs to convert a multi‑page Windows Metafile (EMF) report into high‑resolution PNG images (300 DPI) for inclusion in a web portal, they can use this code to split and rasterize each page.
 * 2. When an application must generate printable assets from vector‑based EMF diagrams and ensure consistent DPI across all pages, this snippet automates loading, paging, and exporting to PNG.
 * 3. When a batch‑processing service has to archive each page of a multi‑page EMF document as separate PNG files for digital asset management, the code provides the required page extraction and resolution control.
 * 4. When a developer is building a document preview feature that shows each EMF page as a raster image with 300 DPI quality in a C# WinForms or WPF UI, this example demonstrates how to rasterize and save the pages as PNG.
 * 5. When integrating Aspose.Imaging into a CI pipeline to validate that every page of an EMF design file renders correctly at print‑ready resolution, the code can be used to generate PNGs for visual comparison.
 */