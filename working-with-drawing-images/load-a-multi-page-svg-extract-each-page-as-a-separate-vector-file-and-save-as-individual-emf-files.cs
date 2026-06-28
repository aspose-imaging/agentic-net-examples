using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input SVG path
            string inputPath = @"C:\Images\multpage.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image (supports multipage)
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the image implements IMultipageImage
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                int pageCount = multipage.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    // Construct output file name for each page
                    string outputPath = $@"C:\Images\output_page_{i}.emf";

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Prepare EMF export options
                    EmfOptions exportOptions = new EmfOptions();

                    // Export only the current page
                    exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                    // Set vector rasterization options (page size based on source image)
                    exportOptions.VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save the current page as EMF
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
 * 1. When a CAD application needs to convert each layer of a multi‑page SVG diagram into separate EMF files for Windows vector graphics editing.
 * 2. When an automated reporting system must split a multi‑page SVG chart into individual EMF pages to embed them in PowerPoint slides.
 * 3. When a printing workflow requires extracting each SVG page as an EMF vector to preserve resolution‑independent quality for high‑DPI printers.
 * 4. When a document conversion service wants to transform multi‑page SVG invoices into separate EMF files for inclusion in legacy Word templates.
 * 5. When a GIS tool needs to export each map view stored in a multi‑page SVG as distinct EMF files for further analysis in vector‑based GIS software.
 */