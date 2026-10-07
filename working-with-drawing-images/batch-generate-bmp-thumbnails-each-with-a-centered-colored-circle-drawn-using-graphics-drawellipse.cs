// HOW-TO: Create BMP thumbnails with centered colored circle in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_thumb.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image srcImage = Image.Load(inputPath))
                {
                    int thumbWidth = 150;
                    int thumbHeight = 150;

                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        bmpOptions.Source = new FileCreateSource(outputPath, false);
                        using (Image canvas = Image.Create(bmpOptions, thumbWidth, thumbHeight))
                        {
                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Color.White);
                            graphics.DrawImage(srcImage, 0, 0, thumbWidth, thumbHeight);

                            int radius = Math.Min(thumbWidth, thumbHeight) / 4;
                            int centerX = thumbWidth / 2;
                            int centerY = thumbHeight / 2;
                            int ellipseX = centerX - radius;
                            int ellipseY = centerY - radius;
                            int ellipseDiameter = radius * 2;

                            Pen pen = new Pen(Color.Red, 3);
                            graphics.DrawEllipse(pen, ellipseX, ellipseY, ellipseDiameter, ellipseDiameter);

                            canvas.Save();
                        }
                    }
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
 * 1. When you need to generate 150 × 150 BMP preview images for a batch of photos and add a colored circle overlay to highlight each thumbnail.
 * 2. When a legacy system only accepts BMP files and you must automatically produce small thumbnails with a visual marker for each image.
 * 3. When you want to batch‑process images to create uniform square thumbnails with a white background and a centered ellipse for a product catalog.
 * 4. When a reporting tool requires BMP thumbnails that include a colored circle to indicate status or selection in a batch of files.
 * 5. When preparing sprite assets for a game that uses BMP format and you need to add a centered colored circle to each sprite automatically.
 */
