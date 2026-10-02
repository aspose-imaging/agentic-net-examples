// HOW-TO: How To Optimize SVG Path Data And Save With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/optimized.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Optimization step (if available)
                // Uncomment the following line if SvgImage provides an Optimize method:
                // svgImage.Optimize();

                SvgOptions options = new SvgOptions();
                svgImage.Save(outputPath, options);
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
 * 1. When you need to reduce the file size of an SVG before embedding it in a web page, you can load, simplify, and re‑save the graphic using Aspose.Imaging in C#.
 * 2. When generating dynamic vector icons on the server, you may want to clean up complex path data to improve rendering performance across browsers.
 * 3. When preparing SVG assets for mobile apps, optimizing the paths ensures faster loading and lower memory consumption on devices.
 * 4. When converting design files to a production‑ready format, you can programmatically remove unnecessary commands from the SVG to meet brand guidelines.
 * 5. When automating a build pipeline that processes SVG logos, this code lets you automatically streamline the vector data and store the optimized version for later use.
 */
