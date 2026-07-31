using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\multi_page.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The input image is not a multipage vector image.");
                    return;
                }

                int pageCount = multipage.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = $@"C:\Images\output_page_{i + 1}.emf";

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    EmfOptions exportOptions = new EmfOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1)),
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };

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
 * 1. When a developer needs to convert a multi‑page SVG diagram into separate Windows Metafile (EMF) files for use in Office documents or CAD applications, they can use this C# Aspose.Imaging code.
 * 2. When an automated publishing pipeline must extract each page of a multi‑page vector illustration and save them as individual EMF assets for high‑quality printing, the example shows how to do it.
 * 3. When a web service generates multi‑page SVG reports and the client requires each page as a separate vector file for embedding in PowerPoint slides, this code provides the conversion logic.
 * 4. When a legacy system only supports EMF vector graphics and receives SVG assets with multiple pages, developers can employ this snippet to split and rasterize each page to EMF using Aspose.Imaging for .NET.
 * 5. When a batch processing tool needs to archive each page of a multi‑page SVG map as an independent EMF file for version control and downstream GIS processing, the provided C# example handles the extraction and saving.
 */