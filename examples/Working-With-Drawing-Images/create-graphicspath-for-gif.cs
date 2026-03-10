using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Path to save the resulting GIF
        string outputPath = "output.gif";

        // Create a GIF frame block with desired dimensions
        using (GifFrameBlock frame = new GifFrameBlock(200, 200))
        {
            // Initialize graphics for the frame
            Graphics graphics = new Graphics(frame);
            graphics.Clear(Color.White); // Fill background

            // Create a GraphicsPath instance
            GraphicsPath path = new GraphicsPath();

            // Create a Figure and add a rectangle shape to it
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(20f, 20f, 160f, 160f)));

            // Add the figure to the graphics path
            path.AddFigure(figure);

            // Draw the path onto the frame using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), path);

            // Create a GIF image from the frame and save it
            using (GifImage gif = new GifImage(frame))
            {
                gif.Save(outputPath);
            }
        }
    }
}