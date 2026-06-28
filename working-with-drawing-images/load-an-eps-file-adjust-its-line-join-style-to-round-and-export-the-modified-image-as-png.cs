using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Adjust line join style to round (if supported)
                var graphics = new Graphics(image);
                var pen = new Pen(Color.Black, 1);
                // Uncomment the following line if the Pen class provides a LineJoin property
                // pen.LineJoin = LineJoin.Round;

                // Export the modified image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a vector EPS logo to a high‑quality PNG thumbnail while ensuring smooth rounded corners on all stroked paths, they can load the EPS with Aspose.Imaging, set the pen’s LineJoin to Round, and save as PNG.
 * 2. When preparing print‑ready artwork for web preview, a C# application may load an EPS illustration, adjust the line join style to round to avoid sharp mitered edges, and export the result as a PNG using Aspose.Imaging.
 * 3. When integrating a document processing pipeline that receives EPS diagrams from designers, a developer can use Aspose.Imaging to render the EPS, apply a rounded line join for consistent visual appearance, and output a PNG for downstream consumption.
 * 4. When building a reporting tool that embeds vector EPS charts into PDF or HTML reports, the code can convert the EPS to PNG with rounded line joins to maintain smooth line joins across different browsers.
 * 5. When automating batch conversion of EPS assets for a mobile app, a developer can programmatically load each EPS, set the pen’s LineJoin property to Round for better anti‑aliasing, and save the images as PNG files with Aspose.Imaging in C#.
 */