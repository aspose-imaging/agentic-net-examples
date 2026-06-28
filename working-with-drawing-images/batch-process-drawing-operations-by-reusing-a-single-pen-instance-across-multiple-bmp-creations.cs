using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath1 = @"C:\temp\output\output1.bmp";
            string outputPath2 = @"C:\temp\output\output2.bmp";
            string outputPath3 = @"C:\temp\output\output3.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the input image to obtain its dimensions
            using (Image sourceImage = Image.Load(inputPath))
            {
                int width = sourceImage.Width;
                int height = sourceImage.Height;

                // Create a single Pen instance to be reused across all BMP creations
                Pen sharedPen = new Pen(Color.Blue, 3);

                // Process three BMP files using the same Pen
                ProcessAndSave(width, height, sharedPen, outputPath1);
                ProcessAndSave(width, height, sharedPen, outputPath2);
                ProcessAndSave(width, height, sharedPen, outputPath3);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method that creates a BMP, draws with the shared Pen, and saves it
    static void ProcessAndSave(int width, int height, Pen pen, string outputPath)
    {
        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new BMP image
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Draw a rectangle using the shared Pen instance
            graphics.DrawRectangle(pen, new Rectangle(10, 10, width - 20, height - 20));

            // Save the image (directory already created)
            image.Save();
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating a series of thumbnail BMP files with identical border styling for a product catalog, a developer can reuse a single Pen instance to draw the borders efficiently.
 * 2. When creating multiple map overlay images in BMP format that share the same road‑highlight color and thickness, the shared Pen reduces memory allocations during batch processing.
 * 3. When producing a set of diagnostic BMP screenshots for automated testing, reusing one Pen ensures consistent annotation lines across all images while minimizing object creation overhead.
 * 4. When rendering repeated watermark lines on several BMP assets for a branding workflow, a single Pen instance simplifies the code and speeds up the batch drawing operation.
 * 5. When converting a master BMP template into several variant images with identical frame graphics for a game UI, the shared Pen allows fast reuse of the same drawing style across all output files.
 */