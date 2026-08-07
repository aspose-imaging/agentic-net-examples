using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with compression
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.Compression = BitmapCompression.Rgb;
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create a canvas image bound to the output file
                using (Image image = Image.Create(bmpOptions, 500, 500))
                {
                    // Drawing operations
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Pen for drawing outlines
                    Pen pen = new Pen(Color.Blue, 5);
                    graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));
                    graphics.DrawEllipse(pen, new Rectangle(300, 100, 150, 150));

                    // Fill a rectangle with a solid brush
                    using (SolidBrush brush = new SolidBrush())
                    {
                        brush.Color = Color.LightGreen;
                        brush.Opacity = 100;
                        graphics.FillRectangle(brush, new Rectangle(100, 300, 200, 100));
                    }

                    // Save the image (output path already bound)
                    image.Save();
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
 * 1. When generating printable engineering diagrams that must be stored as loss‑less BMP files with Rgb compression to reduce file size while preserving 24‑bit color fidelity.
 * 2. When creating thumbnail previews of scanned documents in a Windows desktop application and need to draw overlay shapes before saving the BMP with a specific compression level for faster loading.
 * 3. When exporting custom map tiles from a GIS system, drawing borders and labels on a 500×500 canvas and using BmpOptions to set 24‑bit depth and Rgb compression for compatibility with legacy mapping software.
 * 4. When building a medical imaging tool that annotates X‑ray images with rectangles and ellipses and saves the result as a BMP with controlled compression to meet DICOM storage requirements.
 * 5. When developing an automated report generator that programmatically draws charts and fills areas, then saves them as BMP files with a defined compression setting to keep the output files under a size limit for email attachments.
 */