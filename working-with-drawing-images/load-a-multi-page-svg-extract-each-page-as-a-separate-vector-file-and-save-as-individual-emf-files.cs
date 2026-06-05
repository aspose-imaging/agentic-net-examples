using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input SVG path
            string inputPath = "input.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the input directory exists (creates if missing)
            string inputDir = Path.GetDirectoryName(inputPath);
            Directory.CreateDirectory(inputDir);

            // Load the SVG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to multipage interface
                Aspose.Imaging.IMultipageImage multipage = image as Aspose.Imaging.IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage vector image.");
                    return;
                }

                int pageCount = multipage.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    // Prepare EMF export options for the current page
                    EmfOptions exportOptions = new EmfOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(i, i + 1)),
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };

                    // Construct output path for the page
                    string outputPath = Path.Combine(inputDir, $"page_{i + 1}.emf");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer needs to convert a multi‑page SVG diagram into separate EMF files for use in Windows vector graphics applications such as Microsoft Office.
 * 2. When an automated reporting tool must extract each page of an SVG chart and save them as individual EMF images to embed in PDF or Word documents.
 * 3. When a batch processing pipeline processes SVG assets from a design system and requires per‑page EMF output for high‑resolution printing.
 * 4. When a GIS application stores map layers as a multi‑page SVG and the developer wants to export each layer as a standalone EMF vector file for integration with CAD software.
 * 5. When a legacy system only accepts EMF files, a developer can use this code to split a multi‑page SVG logo into separate EMF pages for backward‑compatible rendering.
 */