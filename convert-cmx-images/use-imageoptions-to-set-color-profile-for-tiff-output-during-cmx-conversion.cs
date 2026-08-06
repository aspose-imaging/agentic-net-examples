using System;
using System.IO;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cmx";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output/output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (PngImage pngImage = (PngImage)Aspose.Imaging.Image.Create(pngOptions, width, height))
                {
                    var graphics = new Aspose.Imaging.Graphics(pngImage);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawImage(cmx, 0, 0);
                    pngImage.Save();
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
 * 1. When a CAD application needs to generate preview thumbnails of CMX drawings for web galleries, a developer can use this code to load the CMX file and export it as a PNG image.
 * 2. When an automated reporting system must embed vector‑based CMX diagrams into PDF reports, the code can convert the CMX to a raster PNG that can be inserted into the PDF.
 * 3. When a legacy manufacturing workflow requires converting CMX design files to a web‑friendly format for browser display, this snippet shows how to render the drawing onto a PNG with a white background.
 * 4. When a batch processing job has to create high‑resolution PNG assets from a folder of CMX files for use in marketing materials, the code demonstrates loading each CMX, setting image dimensions, and saving the result.
 * 5. When a document management system needs to generate searchable image previews of uploaded CMX files, developers can employ this example to draw the CMX onto a PNG canvas and store the preview alongside the original file.
 */