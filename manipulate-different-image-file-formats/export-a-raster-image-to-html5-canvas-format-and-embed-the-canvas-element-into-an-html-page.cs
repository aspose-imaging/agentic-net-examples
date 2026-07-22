using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.html";

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
                Html5CanvasOptions options = new Html5CanvasOptions
                {
                    FullHtmlPage = true // Generate a full HTML page with the canvas element
                };

                // Save the image as an HTML5 Canvas file
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
 * 1. When a developer wants to embed a JPEG photo directly into a web page without separate image files, they can export the raster image to an HTML5 Canvas page using Aspose.Imaging for .NET.
 * 2. When building a cross‑platform reporting tool that needs to embed generated charts as canvas elements, the code converts raster chart images into a self‑contained HTML file for easy distribution.
 * 3. When creating an offline documentation viewer that must render images inside a single HTML file, exporting the image to a full HTML5 Canvas page simplifies packaging and loading.
 * 4. When integrating image previews into a C# WinForms or WPF application that uses a WebBrowser control, the developer can generate an HTML5 Canvas file to render the preview without additional image resources.
 * 5. When automating the conversion of a batch of JPEG assets into web‑ready canvas elements for a responsive UI, this code provides a programmatic way to produce HTML files that embed the images as canvas graphics.
 */