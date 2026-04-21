using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Define canvas size
        int width = 500;
        int height = 500;

        // Output directory
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        Directory.CreateDirectory(outputDir);

        // Paths for layer images
        string layer1Path = Path.Combine(outputDir, "layer1.png");
        string layer2Path = Path.Combine(outputDir, "layer2.png");
        string layer3Path = Path.Combine(outputDir, "layer3.png");

        // Ensure directories for layer outputs exist
        Directory.CreateDirectory(Path.GetDirectoryName(layer1Path));
        Directory.CreateDirectory(Path.GetDirectoryName(layer2Path));
        Directory.CreateDirectory(Path.GetDirectoryName(layer3Path));

        // ---------- Create Layer 1 ----------
        Source layer1Source = new FileCreateSource(layer1Path, false);
        PngOptions layer1Options = new PngOptions() { Source = layer1Source };
        using (RasterImage layer1 = (RasterImage)Image.Create(layer1Options, width, height))
        {
            Graphics graphics = new Graphics(layer1);
            graphics.Clear(Color.White);
            graphics.DrawRectangle(new Pen(Color.Red, 5), new Rectangle(50, 50, 400, 400));

            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Black;
                brush.Opacity = 100;
                graphics.DrawString("Layer 1", new Font("Arial", 24), brush, new PointF(60, 60));
            }

            layer1.Save(); // bound image, call Save()
        }

        // ---------- Create Layer 2 ----------
        Source layer2Source = new FileCreateSource(layer2Path, false);
        PngOptions layer2Options = new PngOptions() { Source = layer2Source };
        using (RasterImage layer2 = (RasterImage)Image.Create(layer2Options, width, height))
        {
            Graphics graphics = new Graphics(layer2);
            graphics.Clear(Color.White);
            graphics.DrawEllipse(new Pen(Color.Blue, 5), new Rectangle(100, 100, 300, 300));

            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.DarkGreen;
                brush.Opacity = 100;
                graphics.DrawString("Layer 2", new Font("Arial", 24), brush, new PointF(120, 120));
            }

            layer2.Save();
        }

        // ---------- Create Layer 3 ----------
        Source layer3Source = new FileCreateSource(layer3Path, false);
        PngOptions layer3Options = new PngOptions() { Source = layer3Source };
        using (RasterImage layer3 = (RasterImage)Image.Create(layer3Options, width, height))
        {
            Graphics graphics = new Graphics(layer3);
            graphics.Clear(Color.White);
            graphics.DrawLine(new Pen(Color.Purple, 5), new Point(0, 0), new Point(width, height));
            graphics.DrawLine(new Pen(Color.Purple, 5), new Point(width, 0), new Point(0, height));

            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Brown;
                brush.Opacity = 100;
                graphics.DrawString("Layer 3", new Font("Arial", 24), brush, new PointF(200, 250));
            }

            layer3.Save();
        }

        // Verify layer files exist before merging
        if (!File.Exists(layer1Path)) { Console.Error.WriteLine($"File not found: {layer1Path}"); return; }
        if (!File.Exists(layer2Path)) { Console.Error.WriteLine($"File not found: {layer2Path}"); return; }
        if (!File.Exists(layer3Path)) { Console.Error.WriteLine($"File not found: {layer3Path}"); return; }

        // ---------- Create final canvas ----------
        string tempCanvasPath = Path.Combine(outputDir, "temp_canvas.png");
        Source canvasSource = new FileCreateSource(tempCanvasPath, false);
        PngOptions canvasOptions = new PngOptions() { Source = canvasSource };
        using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, width, height))
        {
            // Merge Layer 1
            using (RasterImage layer = (RasterImage)Image.Load(layer1Path))
            {
                Rectangle bounds = new Rectangle(0, 0, layer.Width, layer.Height);
                canvas.SaveArgb32Pixels(bounds, layer.LoadArgb32Pixels(layer.Bounds));
            }

            // Merge Layer 2
            using (RasterImage layer = (RasterImage)Image.Load(layer2Path))
            {
                Rectangle bounds = new Rectangle(0, 0, layer.Width, layer.Height);
                canvas.SaveArgb32Pixels(bounds, layer.LoadArgb32Pixels(layer.Bounds));
            }

            // Merge Layer 3
            using (RasterImage layer = (RasterImage)Image.Load(layer3Path))
            {
                Rectangle bounds = new Rectangle(0, 0, layer.Width, layer.Height);
                canvas.SaveArgb32Pixels(bounds, layer.LoadArgb32Pixels(layer.Bounds));
            }

            // Export the composition as PDF
            string pdfPath = Path.Combine(outputDir, "composition.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
            PdfOptions pdfOptions = new PdfOptions();
            canvas.Save(pdfPath, pdfOptions);
        }
    }
}