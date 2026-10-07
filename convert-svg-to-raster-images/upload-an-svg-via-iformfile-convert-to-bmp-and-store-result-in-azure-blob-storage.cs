// HOW-TO: Convert SVG to BMP with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.svg";
            string outputPath = "Output\\image.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                BmpOptions options = new BmpOptions();
                options.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
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
 * 1. When a web application receives SVG uploads from users and must produce BMP files for legacy systems that only accept bitmap images.
 * 2. When an automated batch job needs to transform design assets stored as SVG into fixed‑size BMPs for printing workflows.
 * 3. When a desktop utility must preserve the original SVG dimensions while rasterizing it to a BMP with a white background for thumbnail generation.
 * 4. When integrating Aspose.Imaging into a C# service to convert scalable icons into BMPs before storing them in a repository that only supports bitmap formats.
 * 5. When a migration script reads SVG files from a folder, converts them to BMP using vector rasterization options, and saves the results for downstream image‑processing pipelines.
 */
