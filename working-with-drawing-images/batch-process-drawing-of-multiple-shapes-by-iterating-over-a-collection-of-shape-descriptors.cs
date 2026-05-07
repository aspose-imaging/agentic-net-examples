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
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = @"c:\temp\output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the input image
            using (Image inputImage = Image.Load(inputPath))
            {
                int width = inputImage.Width;
                int height = inputImage.Height;

                // Prepare PNG options for the output image
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);

                // Create the output image canvas
                using (Image outputImage = Image.Create(pngOptions, width, height))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(outputImage);
                    graphics.Clear(Color.White);
                    graphics.DrawImage(inputImage, new Point(0, 0));

                    // Collection of shape descriptors
                    var shapes = new (string Type, Color Color, int X1, int Y1, int X2, int Y2)[]
                    {
                        ("Rectangle", Color.Red, 50, 50, 250, 150),   // X1,Y1 = top-left, X2,Y2 = width,height
                        ("Ellipse",   Color.Blue, 300, 200, 450, 350),
                        ("Line",      Color.Green, 100, 300, 400, 300) // X1,Y1 = start, X2,Y2 = end
                    };

                    // Iterate and draw each shape
                    foreach (var s in shapes)
                    {
                        Pen pen = new Pen(s.Color, 2);
                        switch (s.Type)
                        {
                            case "Rectangle":
                                graphics.DrawRectangle(pen, new Rectangle(s.X1, s.Y1, s.X2 - s.X1, s.Y2 - s.Y1));
                                break;
                            case "Ellipse":
                                graphics.DrawEllipse(pen, new Rectangle(s.X1, s.Y1, s.X2 - s.X1, s.Y2 - s.Y1));
                                break;
                            case "Line":
                                graphics.DrawLine(pen, new Point(s.X1, s.Y1), new Point(s.X2, s.Y2));
                                break;
                        }
                    }

                    // Save the output image
                    outputImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}