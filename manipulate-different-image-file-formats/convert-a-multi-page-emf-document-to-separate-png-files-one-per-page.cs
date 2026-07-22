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
            // Hardcoded input EMF file path
            string inputPath = "input.emf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for PNG pages
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page EMF document
            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The provided file is not a multipage vector image.");
                    return;
                }

                int pageCount = multipage.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    // Prepare PNG save options with single‑page export
                    PngOptions pngOptions = new PngOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                    };

                    // Configure vector rasterization to render the EMF page
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = new SizeF(image.Width, image.Height)
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer needs to extract each page of a multi‑page EMF vector file and save them as individual PNG images for web preview or documentation, they can use this C# Aspose.Imaging code.
 * 2. When converting a multi‑page Windows Metafile (EMF) report into separate raster PNG files for inclusion in a PDF or slide deck, this code automates the page‑by‑page rasterization.
 * 3. When an application must generate thumbnail PNGs for every page of a multi‑page EMF diagram to display in a gallery or file manager, the example shows how to load the EMF and export each page.
 * 4. When a batch processing tool has to split a multi‑page vector drawing into standalone PNG assets for downstream image‑processing pipelines, the code demonstrates the required C# operations.
 * 5. When integrating Aspose.Imaging into a C# service that converts legacy EMF documents into PNG pages for mobile devices, this snippet provides the necessary steps to load, rasterize, and save each page.
 */