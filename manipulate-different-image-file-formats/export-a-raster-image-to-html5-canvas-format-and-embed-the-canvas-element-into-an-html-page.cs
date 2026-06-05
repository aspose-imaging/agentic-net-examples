using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/Canvas.html";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Configure HTML5 Canvas export options
                var options = new Html5CanvasOptions
                {
                    // Generate a full HTML page containing the canvas element
                    FullHtmlPage = true
                };

                // Save as HTML5 Canvas
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer wants to display a PNG diagram on a dynamic web page without relying on external image files, they can use this C# code to convert the raster image into an HTML5 Canvas element embedded in a full HTML page.
 * 2. When an e‑learning platform needs to embed interactive graphics that can be programmatically manipulated with JavaScript, the code allows exporting the source image to a canvas‑based HTML page using Aspose.Imaging’s Html5CanvasOptions.
 * 3. When a reporting tool must generate self‑contained HTML reports that include raster charts, the snippet converts the chart PNG into a canvas element so the report can be viewed offline without separate image assets.
 * 4. When a mobile‑first website requires responsive rendering of legacy raster assets, developers can run this code to transform the PNG into a scalable HTML5 Canvas that adapts to different screen sizes.
 * 5. When an automated build pipeline has to produce preview pages for design assets, the example shows how to load a PNG in C#, export it to a full HTML page with a canvas tag, and store it in a designated output folder.
 */