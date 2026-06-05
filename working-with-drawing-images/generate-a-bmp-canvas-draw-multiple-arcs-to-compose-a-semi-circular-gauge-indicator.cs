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
        // Hardcoded paths
        string outputPath = @"C:\Temp\GaugeIndicator.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP image options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            int width = 500;
            int height = 500;

            // Create the image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Outer semi‑circular arc (gauge border)
                Pen outerPen = new Pen(Color.DarkGray, 8);
                Rectangle outerRect = new Rectangle(50, 50, 400, 400);
                graphics.DrawArc(outerPen, outerRect, 180, -180);

                // Inner semi‑circular arc (gauge background)
                Pen innerPen = new Pen(Color.LightGray, 4);
                Rectangle innerRect = new Rectangle(80, 80, 340, 340);
                graphics.DrawArc(innerPen, innerRect, 180, -180);

                // Tick marks (multiple small arcs)
                Pen tickPen = new Pen(Color.Black, 2);
                for (int i = 0; i <= 10; i++)
                {
                    float angle = 180 - i * 18; // 0°, 18°, …, 180°
                    // Convert angle to radians for position calculation
                    double rad = angle * Math.PI / 180.0;
                    // Determine radius for tick start and end
                    int rStart = 210;
                    int rEnd = 230;
                    int cx = width / 2;
                    int cy = height / 2;
                    int x1 = cx + (int)(rStart * Math.Cos(rad));
                    int y1 = cy + (int)(rStart * Math.Sin(rad));
                    int x2 = cx + (int)(rEnd * Math.Cos(rad));
                    int y2 = cy + (int)(rEnd * Math.Sin(rad));
                    graphics.DrawLine(tickPen, x1, y1, x2, y2);
                }

                // Needle (a thick arc segment)
                Pen needlePen = new Pen(Color.Red, 6);
                Rectangle needleRect = new Rectangle(120, 120, 260, 260);
                // Example needle from 180° to 135° (pointing to 45% of the gauge)
                graphics.DrawArc(needlePen, needleRect, 180, -45);

                // Save the image
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
 * 1. When a developer needs to create a BMP dashboard widget using Aspose.Imaging in C# that displays a speedometer‑style semi‑circular gauge for a Windows desktop application.
 * 2. When an IoT solution must generate a lightweight bitmap gauge image on the fly with Aspose.Imaging to embed in a web UI without relying on external image assets.
 * 3. When a reporting engine requires a printable, BMP‑based semi‑circular progress indicator that can be merged into PDF invoices via image processing.
 * 4. When a game developer wants to render a health bar as a semi‑circular gauge on a bitmap texture, saving it as a BMP file for reuse across game levels.
 * 5. When a server‑side monitoring service programmatically draws tick‑marked gauge arcs for temperature readings and archives the results as BMP files for audit logs.
 */