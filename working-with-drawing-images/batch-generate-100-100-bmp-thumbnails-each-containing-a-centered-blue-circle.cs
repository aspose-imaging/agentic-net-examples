using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            // Ensure input and output directories exist
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] inputFiles = Directory.GetFiles(inputFolder);

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with bound file source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create a 100x100 BMP canvas
                using (Image canvas = Image.Create(bmpOptions, 100, 100))
                {
                    // Draw on the canvas
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    using (SolidBrush blueBrush = new SolidBrush(Aspose.Imaging.Color.Blue))
                    {
                        // Draw a centered blue circle (filled ellipse)
                        graphics.FillEllipse(blueBrush, new Rectangle(0, 0, 100, 100));
                    }

                    // Save the bound image
                    canvas.Save();
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
 * 1. When a developer needs to automatically generate a set of 100 × 100 BMP icons with a centered blue circle for a Windows desktop application's toolbar, this code can batch‑process source files and output ready‑to‑use thumbnails.
 * 2. When building a legacy embedded system that only supports 24‑bit BMP images, the snippet can create uniform placeholder graphics for device menus by converting any input files into 100 × 100 BMP thumbnails with a blue circle.
 * 3. When preparing a dataset for computer‑vision testing, a programmer can employ the code to produce a large collection of small BMP samples containing a known blue circle pattern for algorithm validation.
 * 4. When a web service must supply thumbnail previews of user‑uploaded images in BMP format for an older client application, the batch routine creates 100 × 100 BMP previews with a consistent blue‑circle watermark.
 * 5. When automating the creation of printable sticker sheets where each sticker is a 100 × 100 BMP image with a centered blue circle, this C# solution quickly generates all required files from a folder of source assets.
 */