// HOW-TO: Create BMP With Custom Dashed Line Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\dashed_line.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 100;

            var bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (var image = Image.Create(bmpOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.Yellow);

                var pen = new Pen(Color.Black, 2);
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 5, 3 };

                graphics.DrawLine(pen, new Point(0, height / 2), new Point(width, height / 2));

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
 * 1. When you need to generate a BMP report that highlights sections with a custom dashed separator line.
 * 2. When creating a diagram in C# where a stylized dashed line indicates a measurement or boundary on a bitmap image.
 * 3. When exporting a game map to BMP and you want to draw a custom patterned road or fence using a dashed stroke.
 * 4. When building a UI thumbnail that requires a yellow background with a black custom dash line for visual emphasis.
 * 5. When automating batch image creation for printing labels and you need to add a configurable dashed underline to each BMP file.
 */
