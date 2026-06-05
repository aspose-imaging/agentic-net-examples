using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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
                // Ensure the image supports multipage operations
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                // Prepare vector rasterization options (common for all pages)
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    PageSize = image.Size,
                    // Set background to white (optional)
                    BackgroundColor = Color.White,
                    // Rendering quality settings
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Export each page as a separate PNG with 300 DPI
                for (int i = 0; i < pageCount; i++)
                {
                    // Construct output file path for the current page
                    string outputPath = Path.Combine("output", $"page_{i + 1}.png");

                    // Ensure output directory exists
                    string outputDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrWhiteSpace(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Configure PNG options for the current page
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        // Set resolution to 300 DPI
                        pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                        // Assign vector rasterization options
                        pngOptions.VectorRasterizationOptions = vectorOptions;

                        // Export only the current page
                        pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                        // Save the page as PNG
                        image.Save(outputPath, pngOptions);
                    }
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
 * 1. When a C# application must convert a multi‑page Windows Metafile (EMF) report into high‑resolution PNG images for inclusion in a PDF catalog, this code splits each page and rasterizes it at 300 DPI.
 * 2. When an automated document processing pipeline needs to extract individual slides from an EMF presentation and save them as PNG thumbnails for a web gallery, the code provides page‑by‑page export with consistent DPI.
 * 3. When a legacy engineering drawing stored as a multi‑page EMF file must be archived as lossless PNG files for long‑term storage and compliance auditing, this routine renders each page at 300 DPI using Aspose.Imaging.
 * 4. When a desktop utility generates printable marketing assets by converting each page of a multi‑page EMF brochure into separate 300 DPI PNG files for high‑quality print production, the code handles the rasterization and file output.
 * 5. When a batch job processes incoming EMF invoices, extracting each page as a 300 DPI PNG to feed an OCR engine that requires raster images, this example demonstrates the necessary page splitting and export steps.
 */