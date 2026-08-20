// HOW-TO: Add Frame Index Labels to APNG and Export as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.apng";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                for (int i = 0; i < apng.PageCount; i++)
                {
                    ApngFrame frame = (ApngFrame)apng.Pages[i];
                    Graphics graphics = new Graphics(frame);
                    Font font = new Font("Arial", 12);
                    SolidBrush brush = new SolidBrush(Color.Yellow);
                    graphics.DrawString($"Frame {i}", font, brush, new Point(5, 5));
                }

                GifOptions gifOptions = new GifOptions();
                apng.Save(outputPath, gifOptions);
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
 * 1. When you need to convert an animated PNG to a GIF while showing each original frame number on the animation for debugging or documentation.
 * 2. When you want to embed frame index watermarks into an APNG before exporting it as a GIF for use in presentations or tutorials.
 * 3. When a game developer must generate a GIF preview of sprite animations and include the frame order as on‑screen labels.
 * 4. When a web application needs to display an APNG as a GIF with visible frame numbers to help users understand the animation sequence.
 * 5. When automating image processing pipelines with Aspose.Imaging in C# to annotate each frame of an APNG and produce a GIF for platforms that only support GIF animation.
 */
