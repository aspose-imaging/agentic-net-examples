using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.jpg");
        string outputHtmlPath = Path.Combine("Output", "email.html");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlPath));

        // Load the source image as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Convert the image to PNG and store in a memory stream
            using (MemoryStream pngStream = new MemoryStream())
            {
                var pngOptions = new PngOptions();
                raster.Save(pngStream, pngOptions);
                pngStream.Position = 0;
                byte[] pngBytes = pngStream.ToArray();

                // Encode PNG bytes to Base64
                string base64 = Convert.ToBase64String(pngBytes);

                // Build HTML with embedded PNG
                string html = $"<html><body><h1>Embedded Image</h1><img src=\"data:image/png;base64,{base64}\" alt=\"Embedded Image\"/></body></html>";

                // Write HTML to output file
                File.WriteAllText(outputHtmlPath, html);
            }
        }

        Console.WriteLine($"HTML email saved to: {outputHtmlPath}");
    }
}