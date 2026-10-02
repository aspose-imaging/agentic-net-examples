// HOW-TO: Crop EPS Canvas to Rectangle and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (var eps = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var cropRect = new Rectangle(50, 50, 200, 200);
                eps.Crop(cropRect);

                var options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                eps.Save(outputPath, options);
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
 * 1. When you need to extract a specific region from a vector EPS logo and deliver it as a PNG thumbnail for a web page.
 * 2. When preparing print‑ready artwork, you can crop the EPS page to the area of interest and convert it to PNG for proofing on screen.
 * 3. When automating a workflow that generates product labels, you can trim the EPS template to the label dimensions and save it as a PNG for further processing.
 * 4. When integrating with a content management system that only accepts raster images, you can crop the EPS source and export the result as a PNG for upload.
 * 5. When creating preview images for an EPS catalog, you can programmatically crop each file to a uniform rectangle and convert it to PNG for faster loading.
 */
