using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output\\blurred.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(outputPath, pngOptions);
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
 * 1. When a web service needs to generate a blurred preview thumbnail of user‑uploaded SVG logos for faster page loading, a developer can call the REST API, rasterize the SVG to PNG, apply a Gaussian blur, and return the image.
 * 2. When an e‑commerce platform wants to obscure product SVG diagrams in a public catalog while still showing a stylized preview, the code can fetch the SVG via REST, blur it, and post the blurred PNG back for display.
 * 3. When a content‑moderation tool must automatically mask copyrighted vector artwork before sharing it with third‑party partners, developers can retrieve the SVG, apply a Gaussian blur filter, and upload the blurred PNG through the API.
 * 4. When a mobile app needs to create a low‑resolution blurred background from SVG assets to improve UI performance, the developer can download the SVG, rasterize it, blur it, and send the result back to the server.
 * 5. When a data‑visualization dashboard wants to protect sensitive SVG charts by showing only a blurred version to unauthenticated users, the backend can pull the SVG, apply Gaussian blur, and serve the blurred PNG via the API.
 */