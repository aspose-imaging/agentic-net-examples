using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string inputPath1 = @"input\image1.jpg";
        string inputPath2 = @"input\image2.jpg";
        string inputPath3 = @"input\image3.jpg";

        // Verify each input file exists
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }
        if (!File.Exists(inputPath3))
        {
            Console.Error.WriteLine($"File not found: {inputPath3}");
            return;
        }

        // Paths for intermediate EPS and final PNG output
        string epsPath = @"output\combined.eps";
        string pngPath = @"output\combined.png";

        // Ensure output directories exist (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(epsPath));
        Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

        // Create a multipage image from the JPG files
        string[] jpgFiles = new[] { inputPath1, inputPath2, inputPath3 };
        using (Image multipage = Image.Create(jpgFiles))
        {
            // Save the multipage image as EPS (vector format)
            multipage.Save(epsPath);
        }

        // Load the EPS image and rasterize it to PNG
        using (Image epsImage = Image.Load(epsPath))
        {
            // Export EPS (rasterized) to PNG
            epsImage.Save(pngPath, new PngOptions());
        }
    }
}