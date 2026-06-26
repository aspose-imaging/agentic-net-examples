using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.bmp";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP save options with vector rasterization
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                // Save as BMP
                image.Save(outputPath, bmpOptions);
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
 * 1. When a web application needs to serve legacy BMP thumbnails generated from user‑uploaded SVG logos via an ASP.NET Core controller.
 * 2. When an e‑commerce platform must convert product vector illustrations (SVG) to BMP format for compatibility with a third‑party printing service.
 * 3. When a document management system requires rasterizing scalable SVG diagrams into BMP images for inclusion in PDF reports generated on the server.
 * 4. When a GIS portal needs to transform SVG map overlays into BMP tiles that can be cached and delivered efficiently to browsers.
 * 5. When an internal dashboard must display SVG charts as BMP files to support older Windows client applications that only read BMP resources.
 */