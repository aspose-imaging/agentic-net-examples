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
            string inputPath = "Input/map.pdf";
            string outputPath = "Output/map.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions
                {
                    KeepMetadata = true,
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                image.Save(outputPath, svgOptions);
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
 * 1. When a GIS application needs to convert PDF map files into scalable SVG graphics while preserving the original geographic coordinate metadata for later spatial analysis.
 * 2. When a web‑mapping service wants to serve interactive vector maps on browsers by transforming PDF maps to SVG without losing coordinate reference information embedded in the PDF.
 * 3. When an automated reporting pipeline must extract vector map pages from PDFs and store them as SVG files so that downstream tools can overlay data using the retained geolocation metadata.
 * 4. When a mobile app developer needs to reduce file size by converting high‑resolution PDF maps to lightweight SVG while keeping the coordinate system intact for offline navigation.
 * 5. When a document management system requires batch conversion of archived PDF cartographic documents to SVG format, ensuring that the geographic metadata remains accessible for search and indexing.
 */