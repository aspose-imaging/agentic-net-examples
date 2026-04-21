using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.cmx";
        string outputPath = @"C:\temp\output.emf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            int width = cmx.Width;
            int height = cmx.Height;

            Rectangle frame = new Rectangle(0, 0, width, height);
            var graphics = new EmfRecorderGraphics2D(frame, new Size(width, height), new Size(width / 100, height / 100));

            Pen thickPen = new Pen(Color.Black, 5);
            graphics.DrawLine(thickPen, 0, 0, width, height);
            graphics.DrawLine(thickPen, 0, height, width, 0);

            using (EmfImage emfImage = graphics.EndRecording())
            {
                emfImage.Save(outputPath);
            }
        }
    }
}