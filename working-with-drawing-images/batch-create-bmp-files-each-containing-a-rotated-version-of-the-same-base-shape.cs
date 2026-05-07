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
            // Hardcoded paths
            string baseImagePath = "base.bmp";
            string outputDir = "output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Create base BMP with a simple rectangle shape
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(baseImagePath, false);
            int width = 300;
            int height = 200;

            using (Image baseImage = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(baseImage);
                graphics.Clear(Color.White);
                graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(50, 30, 200, 140));
                baseImage.Save(); // Saves to baseImagePath because source is bound
            }

            // Define rotation/flip types to generate
            RotateFlipType[] rotateTypes = new RotateFlipType[]
            {
                RotateFlipType.Rotate90FlipNone,
                RotateFlipType.Rotate180FlipNone,
                RotateFlipType.Rotate270FlipNone,
                RotateFlipType.RotateNoneFlipX,
                RotateFlipType.RotateNoneFlipY
            };

            foreach (RotateFlipType rotateType in rotateTypes)
            {
                // Verify base image exists
                if (!File.Exists(baseImagePath))
                {
                    Console.Error.WriteLine($"File not found: {baseImagePath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, $"base.{rotateType}.bmp");

                // Load, rotate/flip, and save
                using (Image img = Image.Load(baseImagePath))
                {
                    img.RotateFlip(rotateType);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    img.Save(outputPath, new BmpOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}