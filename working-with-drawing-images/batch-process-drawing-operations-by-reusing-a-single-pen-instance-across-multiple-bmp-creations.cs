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
            // Define output file paths (hardcoded)
            string outputPath1 = @"C:\Temp\output1.bmp";
            string outputPath2 = @"C:\Temp\output2.bmp";
            string outputPath3 = @"C:\Temp\output3.bmp";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3));

            // Create a single reusable Pen instance
            Pen pen = new Pen(Color.Blue, 5);

            // ---------- First BMP ----------
            BmpOptions bmpOptions1 = new BmpOptions();
            bmpOptions1.BitsPerPixel = 24;
            bmpOptions1.Source = new FileCreateSource(outputPath1, false);
            using (Image image1 = Image.Create(bmpOptions1, 400, 300))
            {
                Graphics graphics = new Graphics(image1);
                graphics.Clear(Color.White);
                // Draw a rectangle using the shared Pen
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 300, 200));
                // Save the bound file
                image1.Save();
            }

            // ---------- Second BMP ----------
            BmpOptions bmpOptions2 = new BmpOptions();
            bmpOptions2.BitsPerPixel = 24;
            bmpOptions2.Source = new FileCreateSource(outputPath2, false);
            using (Image image2 = Image.Create(bmpOptions2, 400, 300))
            {
                Graphics graphics = new Graphics(image2);
                graphics.Clear(Color.White);
                // Draw an ellipse using the same Pen
                graphics.DrawEllipse(pen, new Rectangle(100, 75, 200, 150));
                image2.Save();
            }

            // ---------- Third BMP ----------
            BmpOptions bmpOptions3 = new BmpOptions();
            bmpOptions3.BitsPerPixel = 24;
            bmpOptions3.Source = new FileCreateSource(outputPath3, false);
            using (Image image3 = Image.Create(bmpOptions3, 400, 300))
            {
                Graphics graphics = new Graphics(image3);
                graphics.Clear(Color.White);
                // Draw a diagonal line using the shared Pen
                graphics.DrawLine(pen, new Point(0, 0), new Point(399, 299));
                image3.Save();
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
 * 1. When a developer needs to generate multiple BMP reports with consistent line styling, such as drawing rectangles and ellipses on separate bitmap files for a dashboard.
 * 2. When creating a set of thumbnail images for a photo gallery where each thumbnail requires the same border thickness and color, reusing a single Pen improves performance.
 * 3. When automating the production of printable forms (e.g., invoices or certificates) that contain repeated graphic elements like boxes and circles across several BMP pages.
 * 4. When building a batch image processing tool that adds watermarks or decorative shapes to a series of BMP files while maintaining a uniform pen width and color.
 * 5. When developing a game asset pipeline that programmatically draws collision boxes and hit‑area circles onto multiple BMP sprites using a shared Pen instance to ensure visual consistency.
 */