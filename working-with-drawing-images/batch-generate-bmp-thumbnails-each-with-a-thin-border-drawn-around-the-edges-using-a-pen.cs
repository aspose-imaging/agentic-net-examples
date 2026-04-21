using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Set up input and output directories relative to the current directory
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure the input directory exists; if not, create it and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files from the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        // Define thumbnail dimensions and border thickness
        int thumbWidth = 100;
        int thumbHeight = 100;
        int borderThickness = 1;

        foreach (var inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output file path with a BMP extension
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + "_thumb.bmp");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image srcImage = Image.Load(inputPath))
            {
                RasterImage rasterSrc = (RasterImage)srcImage;

                // Calculate canvas size (thumbnail plus border)
                int canvasWidth = thumbWidth + 2 * borderThickness;
                int canvasHeight = thumbHeight + 2 * borderThickness;

                // Prepare BMP options with a FileCreateSource bound to the output path
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create the canvas image
                using (Image canvas = Image.Create(bmpOptions, canvasWidth, canvasHeight))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    // Destination rectangle for the scaled thumbnail inside the border
                    Rectangle destRect = new Rectangle(borderThickness, borderThickness, thumbWidth, thumbHeight);
                    // Source rectangle covering the whole source image
                    Rectangle srcRect = new Rectangle(0, 0, rasterSrc.Width, rasterSrc.Height);

                    // Draw the scaled image onto the canvas
                    graphics.DrawImage(rasterSrc, destRect, srcRect, GraphicsUnit.Pixel);

                    // Draw a thin black border around the canvas
                    Pen borderPen = new Pen(Color.Black, borderThickness);
                    graphics.DrawRectangle(borderPen, 0, 0, canvasWidth - 1, canvasHeight - 1);

                    // Save the canvas; the output path is already bound
                    canvas.Save();
                }
            }
        }
    }
}