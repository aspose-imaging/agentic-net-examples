// HOW-TO: Create 400x400 Yellow BMP Image Using FileStream In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\yellow.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(stream);

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 400))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                    {
                        graphics.FillRectangle(brush, image.Bounds);
                    }
                    image.Save();
                }
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
 * 1. When you need to generate a solid‑color BMP thumbnail for a legacy Windows application that only accepts BMP files.
 * 2. When you want to programmatically create a 400 × 400 yellow canvas as a background for further drawing with Aspose.Imaging graphics.
 * 3. When you must write the BMP directly to a FileStream (such as a network share or temporary folder) while specifying BmpOptions.
 * 4. When you are building a batch job that creates placeholder images for missing assets in a game or UI design pipeline.
 * 5. When you need to produce a fixed‑size BMP image without loading an existing source, useful for automated report generation or testing.
 */
