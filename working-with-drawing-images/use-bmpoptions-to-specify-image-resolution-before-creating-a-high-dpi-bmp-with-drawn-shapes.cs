using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\highdpi_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a FileCreateSource bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Configure BMP options with high DPI resolution
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Compression = BitmapCompression.Rgb;
            bmpOptions.ResolutionSettings = new ResolutionSetting(300.0, 300.0);
            bmpOptions.Source = source;

            // Create a BMP image canvas (bound to the file via the source)
            using (Image image = Image.Create(bmpOptions, 800, 600))
            {
                // Obtain a Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw a blue rectangle
                Pen rectPen = new Pen(Color.Blue, 5);
                graphics.DrawRectangle(rectPen, new Rectangle(100, 100, 200, 150));

                // Fill a red ellipse using a brush (brush wrapped in using)
                using (SolidBrush ellipseBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillEllipse(ellipseBrush, new Rectangle(350, 200, 150, 100));
                }

                // Save the bound image (no path needed)
                image.Save();
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
 * 1. When generating printable marketing materials such as flyers or posters, a developer can use this code to create a high‑DPI 300 dpi BMP with vector‑drawn shapes that retain sharpness when printed.
 * 2. When exporting engineering schematics or architectural diagrams to BMP for legacy CAD systems, setting the resolution ensures the drawn rectangles and ellipses scale correctly on high‑resolution monitors.
 * 3. When producing high‑quality raster assets for medical imaging reports, the code allows embedding precise shapes into a 24‑bit BMP at 300 dpi to meet regulatory image‑clarity standards.
 * 4. When creating custom UI skins or icons for Windows applications that require a specific DPI setting, developers can draw the graphics programmatically and save them as high‑resolution BMP files.
 * 5. When automating the generation of test images for image‑processing algorithms, this snippet lets testers produce consistent 800×600 BMP files with known DPI and drawn primitives for benchmarking.
 */