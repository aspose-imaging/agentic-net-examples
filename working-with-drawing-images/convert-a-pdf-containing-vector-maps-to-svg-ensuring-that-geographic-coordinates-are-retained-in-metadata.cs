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
            string inputPath = "Input\\map.pdf";
            string outputPath = "Output\\map.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgOptions options = new SvgOptions
                {
                    KeepMetadata = true,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                image.Save(outputPath, options);
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
 * 1. When a GIS application needs to display interactive web maps, a developer can use this code to convert PDF vector maps into SVG files while preserving the original geographic coordinate metadata for accurate overlay.
 * 2. When a city planning portal wants to publish printable map PDFs as scalable web graphics, the code enables conversion from PDF to SVG with Aspose.Imaging, keeping the coordinate system intact for downstream spatial analysis.
 * 3. When an engineering firm automates the migration of legacy PDF schematics to responsive SVG diagrams, the snippet ensures vector data and embedded georeferencing information are retained during the C# conversion process.
 * 4. When a mobile navigation app requires lightweight vector assets, developers can run this routine to transform high‑resolution PDF maps into SVG while preserving metadata so the app can align the graphics with GPS coordinates.
 * 5. When a data visualization pipeline extracts map layers from PDFs for use in D3.js charts, the code provides a reliable way to convert the files to SVG with Aspose.Imaging while maintaining the geographic metadata needed for accurate plotting.
 */