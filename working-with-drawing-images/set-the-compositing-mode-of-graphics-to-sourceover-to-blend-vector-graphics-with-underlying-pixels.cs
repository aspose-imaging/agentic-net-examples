using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source and PNG options for the output image
            FileCreateSource source = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions() { Source = source };

            // Create a canvas image (400x300) bound to the output file
            using (Aspose.Imaging.Image canvasImage = Aspose.Imaging.Image.Create(options, 400, 300))
            {
                // Initialize Graphics for the canvas
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvasImage);

                // Clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Fill a rectangle with solid red color
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.Red;
                    graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(50, 50, 200, 150));
                }

                // Save the bound image (no need to specify path again)
                canvasImage.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}