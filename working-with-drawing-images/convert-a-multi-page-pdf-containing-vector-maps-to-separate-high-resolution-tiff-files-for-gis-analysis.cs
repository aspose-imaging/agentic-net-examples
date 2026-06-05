using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PDF path
            string inputPath = "Input\\maps.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output image path
            string outputPath = "Output\\page1.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Ensure the loaded image supports multiple pages
                var multipage = image as Aspose.Imaging.IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The input file is not a multipage image.");
                    return;
                }

                // Save the first page as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a GIS analyst needs to extract each page of a multi‑page PDF containing vector maps and save them as high‑resolution TIFF files for precise spatial analysis using C# and Aspose.Imaging.
 * 2. When a municipal planning department wants to automate the conversion of a PDF atlas of city maps into separate TIFF images that retain vector detail for integration with their mapping software.
 * 3. When a remote‑sensing developer must programmatically split a large PDF of satellite imagery into individual TIFF files to feed a raster‑processing pipeline in a .NET application.
 * 4. When a construction firm requires a batch process that loads a multi‑page PDF blueprint, verifies it is a multipage image, and outputs each page as a lossless TIFF for archival and quality‑control purposes.
 * 5. When a web‑based GIS portal needs to dynamically render PDF map pages as high‑resolution TIFFs on the server side using Aspose.Imaging to serve fast, high‑quality map tiles to clients.
 */