using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            int width = epsImage.Width;
            int height = epsImage.Height;

            // Draw border frame
            Graphics graphics = new Graphics(epsImage);
            int borderThickness = 10;
            Pen pen = new Pen(Color.Black, borderThickness);
            graphics.DrawRectangle(pen, new Rectangle(borderThickness / 2, borderThickness / 2, width - borderThickness, height - borderThickness));

            // Save as lossless PNG
            var pngOptions = new PngOptions();
            epsImage.Save(outputPath, pngOptions);
        }
    }
}