using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24,
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };

                    image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to convert a whole folder of SVG graphics into 24‑bit BMP images for compatibility with legacy Windows software, this C# batch‑processing code using Aspose.Imaging provides a quick solution.
 * 2. When an automated build pipeline must rasterize vector SVG assets into high‑quality BMP files with a white background for printing or documentation, the example demonstrates how to handle the conversion in .NET.
 * 3. When a web service has to generate thumbnail BMP previews of uploaded SVG files on the server side, the code shows how to iterate through a directory, load each SVG, and save it as a 24‑bit bitmap.
 * 4. When a desktop application needs to migrate a legacy image repository from scalable SVG format to fixed‑size BMP files for faster loading in older environments, this snippet illustrates the required file‑system and image‑processing steps.
 * 5. When a data‑migration script must ensure all vector icons are stored as BMP with consistent color depth before archiving, the example provides the necessary C# logic to batch convert and organize the output files.
 */