using System;
using System.IO;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "background.png";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load background image
        using (Aspose.Imaging.RasterImage background = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Create the first GIF frame from the background image
            using (GifFrameBlock firstBlock = new GifFrameBlock(background))
            using (GifImage gifImage = new GifImage(firstBlock))
            {
                // Define a pen for drawing outlines
                Aspose.Imaging.Pen outlinePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                // Define a solid brush for filling shapes
                SolidBrush fillBrush = new SolidBrush(Aspose.Imaging.Color.Red);

                // Create additional frames with animated shapes
                for (int frameIndex = 0; frameIndex < 5; frameIndex++)
                {
                    // Create a new blank frame with same dimensions as background
                    using (GifFrameBlock frameBlock = new GifFrameBlock((ushort)background.Width, (ushort)background.Height))
                    {
                        // Create graphics for the frame
                        Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(frameBlock);

                        // Clear the frame with white background
                        graphics.Clear(Aspose.Imaging.Color.White);

                        // Create a GraphicsPath
                        Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();

                        // Create a figure
                        Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                        // Add a moving rectangle shape to the figure
                        float rectSize = 50f;
                        float offset = frameIndex * 20f;
                        figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(offset, offset, rectSize, rectSize)));

                        // Add the figure to the path
                        path.AddFigure(figure);

                        // Draw the outline of the path
                        graphics.DrawPath(outlinePen, path);

                        // Fill the same rectangle
                        graphics.FillPath(fillBrush, path);

                        // Add the completed frame to the GIF
                        gifImage.AddBlock(frameBlock);
                    }
                }

                // Save the animated GIF
                gifImage.Save(outputPath);
            }
        }
    }
}